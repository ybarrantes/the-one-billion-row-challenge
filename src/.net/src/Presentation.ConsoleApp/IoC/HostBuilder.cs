using Infra.Utils.DependencyInjection;
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
                    .AddProcessorAsLineByLineString()
                    .AddInfraUtilsServices();
            })
            .Build();
    }
}