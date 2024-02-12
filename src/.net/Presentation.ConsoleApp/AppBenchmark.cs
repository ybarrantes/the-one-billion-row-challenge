using BenchmarkDotNet.Attributes;
using Domain.Shared.Types;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp.IoC;
using HostBuilder = Presentation.ConsoleApp.IoC.HostBuilder;

namespace Presentation.ConsoleApp;

[MemoryDiagnoser]
public class AppBenchmark
{
    private const string InputPath = @"C:\.dev\Me\the-one-billion-row-challenge\.data\measurements.10_000.txt";
    private const string OutputPath = InputPath + ".bench.out.txt";
    
    private IRunner runnerSpan;
    private IRunner runnerString;

    public void Setup()
    {
        var host = HostBuilder.CreateHost([]);
        runnerSpan = host.ResolveRunner(RunnerType.LineByLineSpan);
        runnerString = host.ResolveRunner(RunnerType.LineByLineString);
    }
    
    [Benchmark]
    public void RunRunnerSpan()
    {
        Console.WriteLine("Span Runner");
        runnerSpan.Run(InputPath, OutputPath);
    }
    
    [Benchmark]
    public void RunRunnerString()
    {
        Console.WriteLine("String Runner");
        runnerString.Run(InputPath, OutputPath);
    }
}