namespace Domain.Contracts.Utils.FileManager.Reader;

public interface ISyncReader
{
    IEnumerable<string> Read(string path);
}