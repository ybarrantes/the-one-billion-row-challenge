using Domain.Contracts.Business;
using Domain.Contracts.Utils.Elapsed;
using Domain.Contracts.Utils.FileManager.Reader;
using Domain.Contracts.Utils.FileManager.Writer;
using Domain.Shared.Types;
using Microsoft.Extensions.DependencyInjection;
using Services.Business.Processor;
using Services.Business.Runner;

namespace Services.Business.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessorServices(this IServiceCollection services)
    {
        services
            .AddKeyedSingleton<IMeasurementProcessor, LineByLineSpanProcessor>(nameof(ProcessorType.LineByLineSpan))
            .AddKeyedSingleton<IMeasurementProcessor, LineByLineStringProcessor>(nameof(ProcessorType.LineByLineString))
            .AddRunners();
        
        return services;
    }
    
    private static IServiceCollection AddRunners(this IServiceCollection services)
    {
        services.AddKeyedSingleton<IRunner, SimpleRunner>(
            nameof(RunnerType.LineByLineSpan),
            (sp, key) =>
                GetSimpleRunner(sp, ReaderType.LineByLine, ProcessorType.LineByLineSpan, ElapsedType.Console));
        
        services.AddKeyedSingleton<IRunner, SimpleRunner>(
            nameof(RunnerType.LineByLineString),
            (sp, key) =>
                GetSimpleRunner(sp, ReaderType.LineByLine, ProcessorType.LineByLineString, ElapsedType.Console));
        
        return services;
    }
    
    private static SimpleRunner GetSimpleRunner(IServiceProvider sp, ReaderType readerType, ProcessorType processorType, ElapsedType elapsedType)
    {
        return new SimpleRunner(
            sp.GetKeyedService<IReader>(readerType.ToString()),
            sp.GetKeyedService<IMeasurementProcessor>(processorType.ToString()),
            sp.GetService<IWriter>(),
            sp.GetKeyedService<IElapsed>(elapsedType.ToString()));
    }
}