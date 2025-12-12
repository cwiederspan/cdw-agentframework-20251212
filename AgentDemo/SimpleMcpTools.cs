using Microsoft.Extensions.AI;

namespace AgentDemo;

/// <summary>
/// Example demonstrating how to create a simple MCP Server tool
/// that can be used by AI agents
/// </summary>
public class SimpleMcpTools
{
    /// <summary>
    /// Example tool that gets the current weather (simulated)
    /// In a real scenario, this would call an actual weather API
    /// </summary>
    public static AIFunction GetWeatherTool()
    {
        return AIFunctionFactory.Create(
            (string location) =>
            {
                // Simulated weather data
                var weather = location.ToLowerInvariant() switch
                {
                    var loc when loc.Contains("seattle") => "Rainy, 55°F",
                    var loc when loc.Contains("miami") => "Sunny, 85°F",
                    var loc when loc.Contains("new york") => "Cloudy, 68°F",
                    var loc when loc.Contains("london") => "Foggy, 60°F",
                    _ => "Clear, 72°F"
                };
                
                return $"The weather in {location} is: {weather}";
            },
            name: "get_weather",
            description: "Gets the current weather for a location"
        );
    }

    /// <summary>
    /// Example tool that performs simple calculations
    /// </summary>
    public static AIFunction CalculatorTool()
    {
        return AIFunctionFactory.Create(
            (double a, double b, string operation) =>
            {
                return operation.ToLowerInvariant() switch
                {
                    "add" => $"{a} + {b} = {a + b}",
                    "subtract" => $"{a} - {b} = {a - b}",
                    "multiply" => $"{a} × {b} = {a * b}",
                    "divide" when b != 0 => $"{a} ÷ {b} = {a / b}",
                    "divide" => "Error: Division by zero",
                    _ => "Error: Unknown operation"
                };
            },
            name: "calculate",
            description: "Performs basic arithmetic operations: add, subtract, multiply, divide"
        );
    }

    /// <summary>
    /// Example tool that gets system information
    /// </summary>
    public static AIFunction GetSystemInfoTool()
    {
        return AIFunctionFactory.Create(
            () =>
            {
                var info = new
                {
                    Platform = Environment.OSVersion.Platform.ToString(),
                    OSVersion = Environment.OSVersion.VersionString,
                    MachineName = Environment.MachineName,
                    ProcessorCount = Environment.ProcessorCount,
                    DotNetVersion = Environment.Version.ToString(),
                    CurrentDirectory = Environment.CurrentDirectory
                };

                return $"""
                    System Information:
                    - Platform: {info.Platform}
                    - OS Version: {info.OSVersion}
                    - Machine Name: {info.MachineName}
                    - Processor Count: {info.ProcessorCount}
                    - .NET Version: {info.DotNetVersion}
                    - Current Directory: {info.CurrentDirectory}
                    """;
            },
            name: "get_system_info",
            description: "Gets information about the current system"
        );
    }
}
