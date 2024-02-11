namespace Domain.Contracts.Business.Runner;

public interface ISyncRunner
{
    void Run(string inputPath, string outputPath);
}