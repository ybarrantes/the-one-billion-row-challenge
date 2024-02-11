using Domain.Dto;

namespace Domain.Contracts.Utils.FileManager.Writer;

public interface IAsyncWriter
{
    Task WriteAsync(string path, IDictionary<string, Measurement> measurements);
}