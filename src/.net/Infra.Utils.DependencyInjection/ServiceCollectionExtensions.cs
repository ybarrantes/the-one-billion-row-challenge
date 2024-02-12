using Domain.Contracts.Utils.Elapsed;
using Domain.Contracts.Utils.FileManager.Reader;
using Domain.Contracts.Utils.FileManager.Writer;
using Domain.Shared.Types;
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
            .AddKeyedSingleton<IElapsed, ConsoleElapsedUtil>(nameof(ElapsedType.Console))
            .AddKeyedSingleton<IElapsed, NoneElapsedUtil>(nameof(ElapsedType.None))
            .AddKeyedSingleton<IReader, LineByLineReader>(nameof(ReaderType.LineByLine))
            .AddSingleton<IWriter, Writer>();
        
        return services;
    }
}