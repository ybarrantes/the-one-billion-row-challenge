using Domain.Contracts.Business;
using Domain.Dto;
using Domain.Shared;

namespace Services.Business.Processor;

internal class LineByLineStringProcessor : IMeasurementProcessor
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
    
    private static void UpdateMeasurement(Dictionary<string, Measurement> measurements, string input)
    {
        var data = input.Split(Constants.MeasurementSeparator);
        
        if (data.Length != 2)
        {
            return;
        }
        
        var city = data[0];
        
        var temp = data[1];
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