// See https://aka.ms/new-console-template for more information

using Domain.Contracts.Business;
using Domain.Contracts.Utils;
using Infra.Utils.Elapsed;
using Infra.Utils.FileManager.Reader;
using Infra.Utils.FileManager.Writer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Business.Processor;
using Services.Business.Runner;

const string inputFilePath = @"C:\.dev\Me\the-one-billion-row-challenge\.data\measurements.30_000_000.txt";
const string outputFilePath = inputFilePath + ".out.txt";

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<ISyncRunner, SimpleSyncRunner>()
    .AddSingleton<IMeasurementProcessor, SimpleProcessor>()
    .AddSingleton<ISyncElapsed, SyncElapsedUtil>()
    .AddSingleton<ISyncReader, LineByLineSyncReader>()
    .AddSingleton<ISyncWriter, SimpleSyncWriter>();

var host = builder.Build();

var runner = host.Services.GetRequiredService<ISyncRunner>();

// runner.Run(args[0], args[1]);
runner.Run(inputFilePath, outputFilePath);
