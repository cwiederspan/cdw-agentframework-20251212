# MCP Server Integration Example

This example demonstrates how to use the Microsoft Agent Framework with MCP (Model Context Protocol) Servers.

## About MCP

Model Context Protocol (MCP) is an open protocol that standardizes how AI applications connect to external data sources and tools. It enables agents to access:

- **Tools**: Functions the agent can call
- **Resources**: Data and content the agent can read
- **Prompts**: Pre-defined prompt templates

## Prerequisites

To run the MCP Server example, you'll need:

1. **Node.js**: For running the MCP server (npx command)
2. **OpenAI API Key**: Set as environment variable
3. **Azure OpenAI** (optional): Can use Azure instead of OpenAI

## Example Code

Here's how to create an agent that uses an MCP Server (based on the official sample):

```csharp
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;
using OpenAI.Chat;

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") 
    ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") 
    ?? "gpt-4o-mini";

// Create an MCP Client for the GitHub server
await using var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Name = "MCPServer",
        Command = "npx",
        Arguments = ["-y", "--verbose", "@modelcontextprotocol/server-github"],
    }));

// Retrieve the list of tools available on the GitHub server
var mcpTools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

// Create an AI agent with the MCP tools
AIAgent agent = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureCliCredential())
     .GetChatClient(deploymentName)
     .CreateAIAgent(
         instructions: "You answer questions related to GitHub repositories only.", 
         tools: [.. mcpTools.Cast<AITool>()]);

// Invoke the agent with a GitHub-related query
Console.WriteLine(await agent.RunAsync(
    "Summarize the last four commits to the microsoft/agent-framework repository?"));
```

## Running the Example

### Option 1: Using Azure OpenAI

```bash
# Set environment variables
export AZURE_OPENAI_ENDPOINT="https://your-resource.openai.azure.com/"
export AZURE_OPENAI_DEPLOYMENT_NAME="gpt-4o-mini"

# Authenticate with Azure CLI
az login

# Run the example
dotnet run
```

### Option 2: Using OpenAI

To adapt the example for OpenAI instead of Azure:

```csharp
using System.ClientModel;
using Microsoft.Agents.AI;
using OpenAI;
using OpenAI.Chat;
using ModelContextProtocol.Client;
using Microsoft.Extensions.AI;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") 
    ?? throw new InvalidOperationException("OPENAI_API_KEY is not set.");
var model = Environment.GetEnvironmentVariable("OPENAI_MODEL") ?? "gpt-4o-mini";

// Create an MCP Client for the GitHub server
await using var mcpClient = await McpClient.CreateAsync(
    new StdioClientTransport(new()
    {
        Name = "GitHubMCP",
        Command = "npx",
        Arguments = ["-y", "@modelcontextprotocol/server-github"],
    }));

// Get tools from the MCP server
var mcpTools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

// Create agent with MCP tools
AIAgent agent = new OpenAIClient(apiKey)
    .GetChatClient(model)
    .CreateAIAgent(
        instructions: "You help users work with GitHub repositories.",
        tools: [.. mcpTools.Cast<AITool>()]);

// Use the agent
var response = await agent.RunAsync(
    "What are the recent commits in microsoft/agent-framework?");
Console.WriteLine(response.Content.Last().Text);
```

## Available MCP Servers

Microsoft provides several MCP servers you can use:

- **GitHub**: `@modelcontextprotocol/server-github`
- **Filesystem**: `@modelcontextprotocol/server-filesystem`
- **Memory**: `@modelcontextprotocol/server-memory`
- **And more...**

See the [Model Context Protocol documentation](https://modelcontextprotocol.io/) for the full list.

## Learn More

- [Microsoft Agent Framework Documentation](https://learn.microsoft.com/agent-framework/)
- [Agent Framework GitHub Repository](https://github.com/microsoft/agent-framework)
- [Model Context Protocol](https://modelcontextprotocol.io/)
- [MCP Samples](https://github.com/microsoft/agent-framework/tree/main/dotnet/samples/GettingStarted/ModelContextProtocol)
