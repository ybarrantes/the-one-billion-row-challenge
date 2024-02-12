// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Presentation.ConsoleApp;
using Presentation.ConsoleApp.IoC;

var inputFilePath = args[0];
var outputFilePath = $"{inputFilePath}.out.txt";

var host = HostBuilder.CreateHost(args);

var app = new App(host);
app.Run(inputFilePath, outputFilePath);


// Benchmark
//BenchmarkRunner.Run<AppBenchmark>();

// runner.Run(args[0], args[1]);

