using AgentEngine.Agent;

Console.WriteLine("====================================");
Console.WriteLine("        AgentEngine");
Console.WriteLine(" AI Tool Calling Console Agent");
Console.WriteLine("Type 'exit' to quit.");
Console.WriteLine("====================================");

while (true)
{
    Console.Write("\nYou > ");

    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
        continue;

    if (input.ToLower() == "exit")
        break;

    string response = AgentLoop.Run(input);

    Console.WriteLine($"\nAgent > {response}");
}