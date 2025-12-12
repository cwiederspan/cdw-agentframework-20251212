// Copyright (c) Microsoft. All rights reserved.
// This sample demonstrates using Microsoft Agent Framework with MCP Server support.
// Based on samples from: https://github.com/microsoft/agent-framework

using Microsoft.Agents.AI;
using OpenAI;
using OpenAI.Chat;

Console.WriteLine("🤖 Microsoft Agent Framework Demo");
Console.WriteLine("==================================\n");

Console.WriteLine("📦 Packages Used:");
Console.WriteLine("  • Microsoft.Agents.AI v1.0.0-preview.251204.1");
Console.WriteLine("  • Microsoft.Agents.AI.OpenAI v1.0.0-preview.251204.1");
Console.WriteLine("  • ModelContextProtocol v0.5.0-preview.1");
Console.WriteLine();

// Check for API key
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("⚠️  No OPENAI_API_KEY environment variable found.");
    Console.WriteLine("ℹ️  Set OPENAI_API_KEY to run the demo with a live AI agent.\n");
    ShowArchitecture();
    Console.WriteLine("\n📝 To run this demo:");
    Console.WriteLine("   1. Set OPENAI_API_KEY environment variable");
    Console.WriteLine("   2. Optional: Set OPENAI_MODEL (default: gpt-4o-mini)");
    Console.WriteLine("   3. Run: dotnet run\n");
    Console.WriteLine("💡 Example Usage:");
    Console.WriteLine("   export OPENAI_API_KEY=\"sk-...\"");
    Console.WriteLine("   dotnet run\n");
    return;
}

var model = Environment.GetEnvironmentVariable("OPENAI_MODEL") ?? "gpt-4o-mini";

try
{
    Console.WriteLine($"✓ Creating AI Agent with model: {model}...\n");

    // Create an AI agent using Microsoft.Agents.AI
    AIAgent agent = new OpenAIClient(apiKey)
        .GetChatClient(model)
        .CreateAIAgent(
            instructions: "You are a helpful assistant that explains technology concepts clearly and concisely.",
            name: "TechExplainer");

    // Test the agent with a simple question
    Console.WriteLine("📝 Asking: 'What is the Microsoft Agent Framework?'\n");
    
    UserChatMessage chatMessage = new("In 2-3 sentences, explain what the Microsoft Agent Framework is and why it's useful.");

    // Invoke the agent and output the result
    ChatCompletion chatCompletion = await agent.RunAsync([chatMessage]);
    
    Console.WriteLine("💬 Agent Response:");
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(chatCompletion.Content.Last().Text);
    Console.WriteLine(new string('-', 60));
    
    Console.WriteLine("\n✅ Demo completed successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Error: {ex.Message}");
    Console.WriteLine("\nℹ️  Please check your OPENAI_API_KEY and try again.");
}

static void ShowArchitecture()
{
    Console.WriteLine("📊 Microsoft Agent Framework Architecture:");
    Console.WriteLine();
    Console.WriteLine("┌─────────────────────────────────────┐");
    Console.WriteLine("│   Microsoft Agent Framework         │");
    Console.WriteLine("│   (Microsoft.Agents.AI)             │");
    Console.WriteLine("└──────────────┬──────────────────────┘");
    Console.WriteLine("               │");
    Console.WriteLine("               ├─► LLM Providers");
    Console.WriteLine("               │   ├─► OpenAI");
    Console.WriteLine("               │   ├─► Azure OpenAI");
    Console.WriteLine("               │   ├─► Anthropic");
    Console.WriteLine("               │   └─► Others");
    Console.WriteLine("               │");
    Console.WriteLine("               ├─► Tools & Functions");
    Console.WriteLine("               │");
    Console.WriteLine("               ├─► MCP Servers");
    Console.WriteLine("               │   └─► External Tools & Resources");
    Console.WriteLine("               │");
    Console.WriteLine("               └─► Workflows");
    Console.WriteLine("                   ├─► Agent Orchestration");
    Console.WriteLine("                   ├─► Human-in-the-Loop");
    Console.WriteLine("                   └─► Graph-based Flows");
    Console.WriteLine();
}
