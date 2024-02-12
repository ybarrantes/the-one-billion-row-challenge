using System.Diagnostics;
using Domain.Contracts.Utils.Elapsed;

namespace Infra.Utils.Elapsed;

internal class ConsoleElapsedUtil : IElapsed
{
    public void LogElapsed(Action action, string message = "")
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        Elapsed.LogElapsed.Log(message, stopwatch);
    }
    
    public T LogElapsed<T>(Func<T> action, string message = "")
    {
        var stopwatch = Stopwatch.StartNew();
        var result = action();
        Elapsed.LogElapsed.Log(message, stopwatch);
        return result;
    }
    
    public async Task LogElapsedAsync(Func<Task> action, string message = "")
    {
        var stopwatch = Stopwatch.StartNew();
        await action();
        Elapsed.LogElapsed.Log(message, stopwatch);
    }
    
    public async Task<T> LogElapsedAsync<T>(Func<Task<T>> action, string message = "")
    {
        var stopwatch = Stopwatch.StartNew();
        var result = await action();
        Elapsed.LogElapsed.Log(message, stopwatch);
        return result;
    }
}