namespace Domain.Contracts.Business;

public interface ISyncRunner
{
    void Run(string inputPath, string outputPath);
}