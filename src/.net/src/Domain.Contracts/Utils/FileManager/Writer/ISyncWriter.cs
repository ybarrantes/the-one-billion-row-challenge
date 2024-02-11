using Domain.Dto;

namespace Domain.Contracts.Utils.FileManager.Writer;

public interface ISyncWriter
{
    void Write(string path, IDictionary<string, Measurement> measurements);
}