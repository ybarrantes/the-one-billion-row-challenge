using Domain.Dto;

namespace Domain.Contracts.Business;

public interface IMeasurementProcessor
{
    IDictionary<string, Measurement> Process(IEnumerable<string> measurements);
}