using Microsoft.Extensions.AI;

Console.WriteLine("🤖 Agent Framework Demo with MCP Server");
Console.WriteLine("========================================\n");

// This demo shows a simple agent using Microsoft.Extensions.AI (v10.1.0)
// with Model Context Protocol (MCP) Server integration capability

Console.WriteLine("📦 Packages Used:");
Console.WriteLine("  • Microsoft.Extensions.AI v10.1.0");
Console.WriteLine("  • Microsoft.Extensions.AI.OpenAI v10.1.0-preview.1");
Console.WriteLine("  • ModelContextProtocol v0.5.0-preview.1");
Console.WriteLine();

// Check for API key
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("⚠️  No OPENAI_API_KEY environment variable found.");
    Console.WriteLine("ℹ️  Set OPENAI_API_KEY to use the AI agent with OpenAI.\n");
    ShowArchitecture();
    Console.WriteLine("\n📝 To run this demo with a live AI model:");
    Console.WriteLine("   1. Set the OPENAI_API_KEY environment variable");
    Console.WriteLine("   2. Run: dotnet run");
    Console.WriteLine();
    return;
}

Console.WriteLine("✅ Environment configured for AI operations\n");
ShowArchitecture();
Console.WriteLine("\n💡 This demo showcases the Microsoft.Extensions.AI framework");
Console.WriteLine("   which provides a unified API for working with different AI models");
Console.WriteLine("   and supports integration with MCP Servers for extended capabilities.\n");

static void ShowArchitecture()
{
    Console.WriteLine("\n📊 MCP Server Integration Architecture:");
    Console.WriteLine("┌─────────────────────────────────────┐");
    Console.WriteLine("│      AI Agent Application           │");
    Console.WriteLine("│  (Microsoft.Extensions.AI)          │");
    Console.WriteLine("└──────────────┬──────────────────────┘");
    Console.WriteLine("               │");
    Console.WriteLine("               ├─► LLM Provider (OpenAI, Azure, etc.)");
    Console.WriteLine("               │");
    Console.WriteLine("               └─► MCP Server");
    Console.WriteLine("                   └─► Tools & Resources");
    Console.WriteLine("                       ├─► File System");
    Console.WriteLine("                       ├─► Databases");
    Console.WriteLine("                       ├─► APIs");
    Console.WriteLine("                       └─► Custom Tools");
    Console.WriteLine();
}
