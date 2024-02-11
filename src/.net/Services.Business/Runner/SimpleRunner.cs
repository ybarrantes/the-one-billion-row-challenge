using Domain.Contracts.Business;
using Domain.Contracts.Utils.Elapsed;
using Domain.Contracts.Utils.FileManager.Reader;
using Domain.Contracts.Utils.FileManager.Writer;

namespace Services.Business.Runner;

internal class SimpleRunner : IRunner
{
    private readonly IReader _reader;
    private readonly IMeasurementProcessor _measurementProcessor;
    private readonly IWriter _writer;
    private readonly IElapsed _elapsed;

    public SimpleRunner(
        IReader reader,
        IMeasurementProcessor measurementProcessor,
        IWriter writer,
        IElapsed elapsed)
    {
        _reader = reader;
        _measurementProcessor = measurementProcessor;
        _writer = writer;
        _elapsed = elapsed;
    }

    public void Run(string inputPath, string outputPath)
    {
        _elapsed.LogElapsed(() => 
            RunWithElapsed(inputPath, outputPath), "Total\t\t");
    }
    
    public Task RunAsync(string inputPath, string outputPath)
    {
        throw new NotImplementedException();
    }
    
    private void RunWithElapsed(string inputPath, string outputPath)
    {
        var lines = _elapsed.LogElapsed(() => 
            _reader.Read(inputPath), "Reading\t");
        
        var measurements = _elapsed.LogElapsed(() => 
            _measurementProcessor.Process(lines), "Processing");
        
        _elapsed.LogElapsed(() => 
            _writer.Write(outputPath, measurements), "Writing\t");
    }
}