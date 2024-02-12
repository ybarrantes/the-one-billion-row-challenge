using Domain.Contracts.Business;
using Domain.Dto;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Services.Business.DependencyInjection")]

namespace Services.Business.Processor;

internal class LineByLineSpanProcessor : IMeasurementProcessor
{
    public IDictionary<string, Measurement> Process(IEnumerable<string> measurements)
    {
        var measurementsResult = new Dictionary<string, Measurement>();
        
        foreach (var measurement in measurements)
        {
            UpdateMeasurement(measurementsResult, measurement);
        }
        
        return measurementsResult;
    }
    
    private static void UpdateMeasurement(Dictionary<string, Measurement> measurements, ReadOnlySpan<char> input)
    {
        var index = input.IndexOf(';');
        
        if (index == -1)
        {
            return;
        }
        
        var city = input[..index].ToString();
        
        var temp = input[(index + 1)..];
        if (!decimal.TryParse(temp, out var tempValue))
        {
            return;
        }
        
        if (measurements.TryGetValue(city, out var measurement))
        {
            measurement.UpdateMeasurement(tempValue);
        }
        else
        {
            measurements.Add(city, new Measurement(tempValue));
        }
    }
}