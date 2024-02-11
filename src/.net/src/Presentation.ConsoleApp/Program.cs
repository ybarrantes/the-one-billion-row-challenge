// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Presentation.ConsoleApp.IoC;

const string inputFilePath = @"C:\.dev\Me\the-one-billion-row-challenge\.data\measurements.1_000_000.txt";
const string outputFilePath = inputFilePath + ".out.txt";

var host = HostBuilder.CreateHost(args);
var runner = host.Services.GetRequiredService<IRunner>();

// runner.Run(args[0], args[1]);
runner.Run(inputFilePath, outputFilePath);
