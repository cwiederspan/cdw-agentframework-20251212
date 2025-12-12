# MCP Server Integration Guide

This document explains how to integrate Model Context Protocol (MCP) Servers with your AI agents using Microsoft.Extensions.AI.

## What is MCP?

Model Context Protocol (MCP) is an open protocol that enables AI applications to securely connect to external data sources and tools. It provides a standardized way to expose:

- **Resources**: Data and content that the AI can access (files, databases, APIs)
- **Tools**: Functions the AI can call to perform actions
- **Prompts**: Pre-defined prompt templates for common tasks

## Architecture Overview

```
┌─────────────────────────────────────────────────────────┐
│                   AI Application                        │
│              (Microsoft.Extensions.AI)                  │
└───────────────────────┬─────────────────────────────────┘
                        │
        ┌───────────────┴───────────────┐
        │                               │
        ▼                               ▼
┌──────────────┐              ┌──────────────────┐
│ LLM Provider │              │   MCP Server(s)  │
│ (OpenAI,     │              │                  │
│  Azure, etc.)│              │  ┌─────────────┐ │
└──────────────┘              │  │ Tools       │ │
                              │  ├─────────────┤ │
                              │  │ Resources   │ │
                              │  ├─────────────┤ │
                              │  │ Prompts     │ │
                              │  └─────────────┘ │
                              └──────────────────┘
```

## How It Works

### 1. Tool Registration

Tools are registered with the AI client and exposed via the MCP protocol:

```csharp
using Microsoft.Extensions.AI;

// Define a tool using AIFunctionFactory
var weatherTool = AIFunctionFactory.Create(
    (string location) => {
        // Call weather API
        return GetWeatherData(location);
    },
    name: "get_weather",
    description: "Gets current weather for a location"
);

// Add tool to chat client
var chatClient = CreateChatClient();
var chatClientWithTools = new ChatClientBuilder(chatClient)
    .UseFunctionInvocation()
    .Build();
```

### 2. AI-Driven Tool Calling

When a user asks a question that requires external data, the AI:

1. Recognizes the need for a tool
2. Generates parameters for the tool call
3. Invokes the tool through MCP
4. Receives the result
5. Incorporates the result into its response

```csharp
var messages = new List<ChatMessage>
{
    new(ChatRole.User, "What's the weather like in Seattle?")
};

// AI automatically decides to call get_weather("Seattle")
var response = await chatClient.CompleteAsync(messages, new ChatOptions
{
    Tools = [weatherTool]
});
```

### 3. MCP Server Benefits

**For Developers:**
- Standard protocol for tool integration
- Reusable server implementations
- Security and access control built-in

**For AI Applications:**
- Access to external data and services
- Consistent interface across different tools
- Better context and more accurate responses

## Example MCP Server Tools

### Weather Service
```csharp
public static AIFunction CreateWeatherTool()
{
    return AIFunctionFactory.Create(
        (string location) => {
            // In production, call actual weather API
            var weather = WeatherService.GetCurrent(location);
            return $"Temperature: {weather.Temp}°F, Conditions: {weather.Conditions}";
        },
        name: "get_weather",
        description: "Gets current weather for a specified location"
    );
}
```

### Database Query
```csharp
public static AIFunction CreateDatabaseQueryTool()
{
    return AIFunctionFactory.Create(
        (string query) => {
            // Execute safe, parameterized query
            using var connection = new SqlConnection(connectionString);
            var results = connection.Query(query);
            return JsonSerializer.Serialize(results);
        },
        name: "query_database",
        description: "Executes a read-only database query"
    );
}
```

### File System Access
```csharp
public static AIFunction CreateFileReadTool()
{
    return AIFunctionFactory.Create(
        (string path) => {
            // Validate and read file with security checks
            if (!IsPathAllowed(path))
                throw new UnauthorizedAccessException();
            
            return File.ReadAllText(path);
        },
        name: "read_file",
        description: "Reads the contents of a file"
    );
}
```

## Security Considerations

1. **Authentication**: Verify the identity of clients connecting to your MCP server
2. **Authorization**: Implement proper access controls for tools and resources
3. **Input Validation**: Validate all parameters before executing tool functions
4. **Rate Limiting**: Prevent abuse by limiting request frequency
5. **Audit Logging**: Log all tool invocations for security monitoring

## Next Steps

To build a production-ready MCP Server integration:

1. Review the [MCP Specification](https://modelcontextprotocol.io/)
2. Implement proper authentication and authorization
3. Add comprehensive error handling
4. Set up monitoring and logging
5. Write tests for your tools
6. Document your tools for users

## Resources

- [Microsoft.Extensions.AI Documentation](https://learn.microsoft.com/en-us/dotnet/ai/)
- [Model Context Protocol](https://modelcontextprotocol.io/)
- [OpenAI Function Calling](https://platform.openai.com/docs/guides/function-calling)
- [.NET AI Samples](https://github.com/dotnet/ai-samples)
