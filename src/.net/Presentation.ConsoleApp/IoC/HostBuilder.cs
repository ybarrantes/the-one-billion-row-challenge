using Domain.Shared.Types;
using Infra.Utils.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Business.DependencyInjection;

namespace Presentation.ConsoleApp.IoC;

public static class HostBuilder
{
    public static IHost CreateHost(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddProcessorServices()
                    .AddInfraUtilsServices();
            })
            .Build();
    }
    
    public static IRunner? ResolveRunner(this IHost host, RunnerType runnerType)
    {
        return runnerType switch
        {
            RunnerType.LineByLineSpan => host.Services.GetKeyedService<IRunner>(nameof(RunnerType.LineByLineSpan)),
            RunnerType.LineByLineString => host.Services.GetKeyedService<IRunner>(nameof(RunnerType.LineByLineString)),
            _ => throw new ArgumentOutOfRangeException(nameof(runnerType), runnerType, null)
        };
    }
}