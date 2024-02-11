namespace Domain.Contracts.Utils.FileManager.Reader;

public interface IAsyncReader
{
    IAsyncEnumerable<string> ReadAsync(string path);
}