using Domain.Contracts.Business;
using Microsoft.Extensions.DependencyInjection;
using Services.Business.Processor;
using Services.Business.Runner;

namespace Services.Business.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessorAsLineByLineString(this IServiceCollection services)
    {
        services
            .AddSingleton<IRunner, SimpleRunner>()
            .AddSingleton<IMeasurementProcessor, LineByLineStringSimpleProcessor>();
        
        return services;
    }
    
    public static IServiceCollection AddProcessorAsLineByLineSpan(this IServiceCollection services)
    {
        services
            .AddSingleton<IRunner, SimpleRunner>()
            .AddSingleton<IMeasurementProcessor, LineByLineSpanSimpleProcessor>();
        
        return services;
    }
}