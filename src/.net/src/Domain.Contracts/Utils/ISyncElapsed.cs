namespace Domain.Contracts.Utils;

public interface ISyncElapsed
{
    void LogElapsed(Action action, string message = "");
    T LogElapsed<T>(Func<T> action, string message = "");
}