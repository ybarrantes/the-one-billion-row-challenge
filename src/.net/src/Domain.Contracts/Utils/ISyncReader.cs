namespace Domain.Contracts.Utils;

public interface ISyncReader
{
    IEnumerable<string> Read(string path);
}