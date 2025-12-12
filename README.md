# Agent Framework Demo with MCP Server

A demonstration repository using .NET 9 and Microsoft's Agent Framework SDK (beta) to build a simple AI agent with Model Context Protocol (MCP) Server integration capabilities.

## 🎯 Features

- ✅ .NET 9 Console Application
- ✅ Microsoft.Extensions.AI v10.1.0 (latest beta)
- ✅ Microsoft.Extensions.AI.OpenAI v10.1.0-preview.1
- ✅ ModelContextProtocol v0.5.0-preview.1
- ✅ GitHub Codespaces support with .devcontainer
- ✅ Pre-configured with Common Utilities and Azure CLI

## 🚀 Quick Start

### Using GitHub Codespaces

1. Click the "Code" button and select "Open with Codespaces"
2. Wait for the container to build and start
3. The environment includes:
   - .NET 9 SDK
   - Azure CLI
   - Common development utilities (zsh, oh-my-zsh, etc.)

### Local Development

#### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- (Optional) OpenAI API key for live AI demonstrations

#### Build and Run

```bash
cd AgentDemo
dotnet restore
dotnet build
dotnet run
```

## 🔑 Configuration

To use the AI agent with OpenAI:

```bash
export OPENAI_API_KEY="your-api-key-here"
cd AgentDemo
dotnet run
```

## 📦 Project Structure

```
.
├── AgentDemo/              # Main console application
│   ├── Program.cs          # Agent demo implementation
│   └── AgentDemo.csproj    # Project file with package references
├── .devcontainer/          # GitHub Codespaces configuration
│   └── devcontainer.json   # Container setup with features
└── README.md              # This file
```

## 🏗️ Architecture

This demo showcases the integration architecture between AI agents and MCP Servers:

```
┌─────────────────────────────────────┐
│      AI Agent Application           │
│  (Microsoft.Extensions.AI)          │
└──────────────┬──────────────────────┘
               │
               ├─► LLM Provider (OpenAI, Azure, etc.)
               │
               └─► MCP Server
                   └─► Tools & Resources
                       ├─► File System
                       ├─► Databases
                       ├─► APIs
                       └─► Custom Tools
```

## 🧩 Key Components

### Microsoft.Extensions.AI

A unified API abstraction for working with different AI models and providers, making it easy to:
- Switch between different LLM providers
- Add middleware and logging
- Implement caching and retry logic
- Integrate with dependency injection

### Model Context Protocol (MCP)

An open protocol that enables AI agents to securely connect to external data sources and tools:
- Standardized way to expose tools and resources
- Secure and controlled access to external systems
- Extensible architecture for custom integrations

## 📚 Learn More

- [Microsoft.Extensions.AI Documentation](https://learn.microsoft.com/en-us/dotnet/ai/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [.NET 9 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview)

## 📝 License

See [LICENSE](LICENSE) file for details.

