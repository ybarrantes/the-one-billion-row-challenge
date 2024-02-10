using System.Text;
using Domain.Dto;

namespace Infra.Utils.FileManager.Extensions;

public static class MeasurementExtensions
{
    public static StringBuilder ToStringBuilder(this IDictionary<string, Measurement> measurements)
    {
        var stringBuilder = new StringBuilder();
        
        foreach (var measurement in measurements)
        {
            stringBuilder.AppendLine($"{measurement.Key}={measurement.Value}");
        }
        
        return stringBuilder;
    }
}