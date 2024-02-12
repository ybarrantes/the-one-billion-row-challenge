using BenchmarkDotNet.Attributes;
using Domain.Shared.Types;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp.IoC;

namespace Presentation.ConsoleApp;

public class App : IApp
{
    private readonly IHost _host;

    public App(IHost host)
    {
        _host = host;
    }
    
    public void Run(string inputPath, string outputPath)
    {
        var runnerSpan = _host.ResolveRunner(RunnerType.LineByLineSpan);
        var runnerString = _host.ResolveRunner(RunnerType.LineByLineString);
        
        RunRunnerSpan(runnerSpan, inputPath, outputPath);
        RunRunnerString(runnerString, inputPath, outputPath);
    }
    
    public void RunRunnerSpan(IRunner runner, string inputPath, string outputPath)
    {
        Console.WriteLine("Span Runner");
        runner.Run(inputPath, outputPath);
    }
    
    public void RunRunnerString(IRunner runner, string inputPath, string outputPath)
    {
        Console.WriteLine("String Runner");
        runner.Run(inputPath, outputPath);
    }
}