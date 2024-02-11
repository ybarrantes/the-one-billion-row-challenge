using Domain.Contracts.Utils.Elapsed;
using Domain.Contracts.Utils.FileManager.Reader;
using Domain.Contracts.Utils.FileManager.Writer;
using Infra.Utils.Elapsed;
using Infra.Utils.FileManager.Reader;
using Infra.Utils.FileManager.Writer;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Utils.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraUtilsServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IReader, LineByLineReader>()
            .AddSingleton<IWriter, Writer>()
            .AddSingleton<IElapsed, ElapsedUtil>();
        
        return services;
    }
}