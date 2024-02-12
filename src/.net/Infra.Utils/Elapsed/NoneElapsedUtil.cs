using Domain.Contracts.Utils.Elapsed;

namespace Infra.Utils.Elapsed;

public class NoneElapsedUtil : IElapsed
{
    public void LogElapsed(Action action, string message = "")
    {
        action();
    }

    public T LogElapsed<T>(Func<T> action, string message = "")
    {
        return action();
    }

    public async Task LogElapsedAsync(Func<Task> action, string message = "")
    {
        await action();
    }

    public async Task<T> LogElapsedAsync<T>(Func<Task<T>> action, string message = "")
    {
        return await action();
    }
}