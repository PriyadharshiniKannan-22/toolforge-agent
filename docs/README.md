# AgentEngine Console Agent

## Overview

AgentEngine Console Agent is a Proof-of-Concept AI Agent built using C# and .NET.

Unlike traditional chatbots that only generate text, this agent can invoke external tools to retrieve real-world information.

## Features

- Tool Calling Agent
- Current Time Tool
- Weather API Integration
- SQLite Database Query Tool
- Console-based User Interface

## Architecture

User
↓
Console Application
↓
AI Agent Router
↓
-------------------------
| Time Tool            |
| Weather API          |
| SQLite Query Tool    |
-------------------------
↓
Final Response

## Technology Stack

- C#
- .NET
- SQLite
- OpenAI Compatible API / Ollama
- GitHub

## Setup

Clone repository:

git clone <repo-url>

Run:

dotnet restore

dotnet run

## Example Queries

What time is it?

What's the weather in Chennai?

Show all students.

What is Priya's CGPA?

## Assumptions

- Internet required for weather API.
- SQLite contains sample data only.

## Limitations

- Limited tool set.
- Basic routing logic.
- Prototype implementation.