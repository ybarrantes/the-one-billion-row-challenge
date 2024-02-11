namespace Domain.Contracts.Business.Runner;

public interface IAsyncRunner
{
    Task RunAsync(string inputPath, string outputPath);
}