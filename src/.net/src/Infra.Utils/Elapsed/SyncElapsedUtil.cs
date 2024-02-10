using System.Diagnostics;
using Domain.Contracts.Utils;

namespace Infra.Utils.Elapsed;

public class SyncElapsedUtil : ISyncElapsed
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
}