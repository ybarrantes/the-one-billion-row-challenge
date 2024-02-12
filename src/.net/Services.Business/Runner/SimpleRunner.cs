using Domain.Contracts.Business;
using Domain.Contracts.Utils.Elapsed;
using Domain.Contracts.Utils.FileManager.Reader;
using Domain.Contracts.Utils.FileManager.Writer;

namespace Services.Business.Runner;

internal class SimpleRunner(
    IReader reader,
    IMeasurementProcessor measurementProcessor,
    IWriter writer,
    IElapsed elapsed)
    : IRunner
{
    public void Run(string inputPath, string outputPath)
    {
        elapsed.LogElapsed(() => 
            RunWithElapsed(inputPath, outputPath), "Total\t");
    }
    
    public Task RunAsync(string inputPath, string outputPath)
    {
        throw new NotImplementedException();
    }
    
    private void RunWithElapsed(string inputPath, string outputPath)
    {
        var lines = elapsed.LogElapsed(() => 
            reader.Read(inputPath), "Reading\t");
        
        var measurements = elapsed.LogElapsed(() => 
            measurementProcessor.Process(lines), "Processing");
        
        elapsed.LogElapsed(() => 
            writer.Write(outputPath, measurements), "Writing\t");
    }
}