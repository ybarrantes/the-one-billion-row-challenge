using System.Diagnostics.CodeAnalysis;

namespace Infra.Utils.FileManager.Exceptions;

public class FileNotFoundException : System.IO.FileNotFoundException
{
    private FileNotFoundException(string message) : base(message)
    {
    }
    
    /// <summary>
    /// Checks if the file at the given path exists. If the file does not exist, throws a FileNotFoundException.
    /// </summary>
    /// <param name="path">The path of the file to check. This argument must not be null.</param>
    /// <exception cref="ArgumentException">Thrown when path is null or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file at the specified path does not exist.</exception>
    public static void ThrowIfFileNotFound([NotNull] string? path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File not found: {path}");
        }
    }
}
