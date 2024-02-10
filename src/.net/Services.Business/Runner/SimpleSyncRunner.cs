using Domain.Contracts.Business;
using Domain.Contracts.Utils;

namespace Services.Business.Runner;

public class SimpleSyncRunner : ISyncRunner
{
    private readonly ISyncReader _syncReader;
    private readonly IMeasurementProcessor _measurementProcessor;
    private readonly ISyncWriter _syncWriter;
    private readonly ISyncElapsed _syncElapsed;

    public SimpleSyncRunner(
        ISyncReader syncReader,
        IMeasurementProcessor measurementProcessor,
        ISyncWriter syncWriter,
        ISyncElapsed syncElapsed)
    {
        _syncReader = syncReader;
        _measurementProcessor = measurementProcessor;
        _syncWriter = syncWriter;
        _syncElapsed = syncElapsed;
    }

    public void Run(string inputPath, string outputPath)
    {
        _syncElapsed.LogElapsed(() => 
            RunWithElapsed(inputPath, outputPath), "Total\t\t");
    }
    
    private void RunWithElapsed(string inputPath, string outputPath)
    {
        var lines = _syncElapsed.LogElapsed(() => 
            _syncReader.Read(inputPath), "Reading\t");
        
        var measurements = _syncElapsed.LogElapsed(() => 
            _measurementProcessor.Process(lines), "Processing");
        
        _syncElapsed.LogElapsed(() => 
            _syncWriter.Write(outputPath, measurements), "Writing\t");
    }
}