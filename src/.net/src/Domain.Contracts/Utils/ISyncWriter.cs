using Domain.Dto;

namespace Domain.Contracts.Utils;

public interface ISyncWriter
{
    bool Write(string path, IDictionary<string, Measurement> measurements);
}