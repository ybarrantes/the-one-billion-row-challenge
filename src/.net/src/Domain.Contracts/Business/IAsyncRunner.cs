namespace Domain.Contracts.Business;

public interface IAsyncRunner
{
    Task RunAsync(string inputPath, string outputPath);
}