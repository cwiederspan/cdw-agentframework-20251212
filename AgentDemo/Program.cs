using Microsoft.Extensions.AI;
using AgentDemo;

Console.WriteLine("🤖 Agent Framework Demo with MCP Server");
Console.WriteLine("========================================\n");

// This demo shows a simple agent using Microsoft.Extensions.AI (v10.1.0)
// with Model Context Protocol (MCP) Server integration capability

Console.WriteLine("📦 Packages Used:");
Console.WriteLine("  • Microsoft.Extensions.AI v10.1.0");
Console.WriteLine("  • Microsoft.Extensions.AI.OpenAI v10.1.0-preview.1");
Console.WriteLine("  • ModelContextProtocol v0.5.0-preview.1");
Console.WriteLine();

// Demonstrate MCP Server Tools concept
Console.WriteLine("🔧 MCP Server Tools (Conceptual Demo):");
Console.WriteLine("  ✓ get_weather - Gets weather information for a location");
Console.WriteLine("  ✓ calculate - Performs basic arithmetic operations");
Console.WriteLine("  ✓ get_system_info - Gets system information");
Console.WriteLine();

Console.WriteLine("🧪 Tool Examples:\n");

// Demonstrate tool concepts without invoking (showing what they would do)
Console.WriteLine("1️⃣  Weather Tool Example:");
Console.WriteLine("   Function: get_weather(location: string)");
Console.WriteLine("   Example Call: get_weather('Seattle')");
Console.WriteLine("   Expected Output: 'The weather in Seattle is: Rainy, 55°F'");
Console.WriteLine();

Console.WriteLine("2️⃣  Calculator Tool Example:");
Console.WriteLine("   Function: calculate(a: double, b: double, operation: string)");
Console.WriteLine("   Example Call: calculate(42, 8, 'multiply')");
Console.WriteLine("   Expected Output: '42 × 8 = 336'");
Console.WriteLine();

Console.WriteLine("3️⃣  System Info Tool Example:");
Console.WriteLine("   Function: get_system_info()");
Console.WriteLine("   Returns: Platform, OS Version, Processor Count, .NET Version, etc.");
Console.WriteLine();

// Check for API key
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("⚠️  No OPENAI_API_KEY environment variable found.");
    Console.WriteLine("ℹ️  Set OPENAI_API_KEY to enable AI agent with tool calling.\n");
    ShowArchitecture();
    Console.WriteLine("\n📝 To run this demo with a live AI model:");
    Console.WriteLine("   1. Set the OPENAI_API_KEY environment variable");
    Console.WriteLine("   2. Run: dotnet run");
    Console.WriteLine("\n💡 With an API key, the AI agent can automatically call these tools");
    Console.WriteLine("   when responding to user queries that need weather, calculations, or");
    Console.WriteLine("   system information.");
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
