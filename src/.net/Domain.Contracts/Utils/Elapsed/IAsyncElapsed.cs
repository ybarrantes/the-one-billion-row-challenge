namespace Domain.Contracts.Utils.Elapsed;

public interface IAsyncElapsed
{
    Task LogElapsedAsync(Func<Task> action, string message = "");
    Task<T> LogElapsedAsync<T>(Func<Task<T>> action, string message = "");
}