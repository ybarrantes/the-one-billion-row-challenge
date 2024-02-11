using System.Diagnostics;

namespace Infra.Utils.Elapsed;

internal static class LogElapsed
{
    public static void Log(string message, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        
        var fullMessage = stopwatch.Elapsed.ToString();
        
        if (!string.IsNullOrEmpty(message))
        {
            fullMessage = $"{message}\t{fullMessage}";
        }
        
        Console.WriteLine(fullMessage);
    }
}