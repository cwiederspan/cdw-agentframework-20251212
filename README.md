# Agent Framework Demo with MCP Server

A demonstration repository using .NET 9 and Microsoft's Agent Framework SDK (beta) to build a simple AI agent with Model Context Protocol (MCP) Server integration capabilities.

> **Based on**: [Microsoft Agent Framework](https://github.com/microsoft/agent-framework)

## 🎯 Features

- ✅ .NET 9 Console Application
- ✅ Microsoft.Agents.AI v1.0.0-preview.251204.1 (latest beta)
- ✅ Microsoft.Agents.AI.OpenAI v1.0.0-preview.251204.1
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
- (Optional) OpenAI API key or Azure OpenAI endpoint for live AI demonstrations
- (Optional) Node.js for MCP Server examples

#### Build and Run

```bash
cd AgentDemo
dotnet restore
dotnet build
dotnet run
```

## 🔑 Configuration

### Using OpenAI

```bash
export OPENAI_API_KEY="sk-your-api-key-here"
export OPENAI_MODEL="gpt-4o-mini"  # optional, this is the default
cd AgentDemo
dotnet run
```

### Using Azure OpenAI

```bash
export AZURE_OPENAI_ENDPOINT="https://your-resource.openai.azure.com/"
export AZURE_OPENAI_DEPLOYMENT_NAME="gpt-4o-mini"
az login
cd AgentDemo
dotnet run
```

## 📦 Project Structure

```
.
├── AgentDemo/              # Main console application
│   ├── Program.cs          # Simple agent demo
│   └── AgentDemo.csproj    # Project file with package references
├── .devcontainer/          # GitHub Codespaces configuration
│   └── devcontainer.json   # Container setup with features
├── MCP_INTEGRATION.md      # MCP Server integration guide
└── README.md               # This file
```

## 🏗️ Microsoft Agent Framework

The Microsoft Agent Framework is a comprehensive multi-language framework for building, orchestrating, and deploying AI agents. It provides:

### Key Capabilities

- **Multiple LLM Provider Support**: OpenAI, Azure OpenAI, Anthropic, and more
- **Agent Orchestration**: Build complex multi-agent workflows
- **MCP Integration**: Connect to external tools and data via Model Context Protocol
- **Graph-based Workflows**: Define agent interactions with data flows
- **Built-in Observability**: OpenTelemetry integration for monitoring
- **Human-in-the-Loop**: Support for human intervention in workflows

### Architecture

```
┌─────────────────────────────────────┐
│   Microsoft Agent Framework         │
│   (Microsoft.Agents.AI)             │
└──────────────┬──────────────────────┘
               │
               ├─► LLM Providers
               │   ├─► OpenAI
               │   ├─► Azure OpenAI
               │   ├─► Anthropic
               │   └─► Others
               │
               ├─► Tools & Functions
               │
               ├─► MCP Servers
               │   └─► External Tools & Resources
               │
               └─► Workflows
                   ├─► Agent Orchestration
                   ├─► Human-in-the-Loop
                   └─► Graph-based Flows
```

## 🧩 Model Context Protocol (MCP)

MCP is an open protocol that enables AI agents to securely connect to external data sources and tools. See [MCP_INTEGRATION.md](MCP_INTEGRATION.md) for detailed examples.

### What MCP Provides

- **Standardized Tool Integration**: Consistent interface for tools and resources
- **Security**: Built-in authentication and authorization
- **Reusability**: Share MCP servers across different applications

### Example MCP Servers

- **GitHub**: Query repositories, issues, PRs
- **Filesystem**: Read and write files
- **Memory**: Persistent agent memory
- **Database**: Query databases
- **Custom**: Build your own MCP servers

## 📚 Learn More

- [Microsoft Agent Framework Documentation](https://learn.microsoft.com/agent-framework/)
- [Agent Framework GitHub Repository](https://github.com/microsoft/agent-framework)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [.NET 9 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview)
- [Agent Framework Samples](https://github.com/microsoft/agent-framework/tree/main/dotnet/samples)

## 📝 License

See [LICENSE](LICENSE) file for details.

