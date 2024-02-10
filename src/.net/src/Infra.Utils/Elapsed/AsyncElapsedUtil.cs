using System.Diagnostics;
using Domain.Contracts.Utils;

namespace Infra.Utils.Elapsed;

public class AsyncElapsedUtil : IAsyncElapsed
{
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