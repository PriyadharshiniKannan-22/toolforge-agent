using Microsoft.AspNetCore.Mvc;
using ToolForge.Agent;
using ToolForge.Api.Models;
using System.Diagnostics;

namespace ToolForge.Api;

[ApiController]
[Route("api")]
public class ChatController : ControllerBase
{
    private readonly AgentLoop _agent;

    public ChatController(AgentLoop agent)
    {
        _agent = agent;
    }

    [HttpPost("chat")]
    public async Task<IActionResult> Chat(
        [FromBody] ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest(new
            {
                error = "Message is required."
            });
        }

        try
        {
            var stopwatch = Stopwatch.StartNew();

            var result =
                await _agent.RunAsync(request.Message);

            stopwatch.Stop();

            Console.WriteLine(
                $"Request completed in {stopwatch.ElapsedMilliseconds} ms"
            );

            return Ok(new
            {
                reply = result.Reply,

                usage = new
                {
                    inputTokens = result.InputTokens,
                    outputTokens = result.OutputTokens,
                    toolCalls = result.ToolCalls,
                    latencyMs = result.LatencyMs
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION:");
            Console.WriteLine(ex.ToString());

            return StatusCode(500, new
            {
                error = ex.ToString()
            });
        }
    }

    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok(new
        {
            status = "ok",
            timestamp = DateTime.UtcNow
        });
    }
}