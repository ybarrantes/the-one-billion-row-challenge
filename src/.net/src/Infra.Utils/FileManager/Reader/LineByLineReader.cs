using Domain.Contracts.Utils.FileManager.Reader;
using FileNotFoundException = Infra.Utils.FileManager.Exceptions.FileNotFoundException;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Infra.Utils.DependencyInjection")]

namespace Infra.Utils.FileManager.Reader;

internal class LineByLineReader : IReader
{
    /// <summary>
    /// Reads a file line by line.
    /// </summary>
    /// <param name="path">The path of the file to read. This argument must not be null.</param>
    /// <returns>An IEnumerable of strings, each representing a line in the file.</returns>
    /// <exception cref="ArgumentException">Thrown when path is null or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file at the specified path does not exist.</exception>
    public IEnumerable<string> Read(string path)
    {
        FileNotFoundException.ThrowIfFileNotFound(path);
        return File.ReadLines(path);
    }

    public IAsyncEnumerable<string> ReadAsync(string path)
    {
        FileNotFoundException.ThrowIfFileNotFound(path);
        return File.ReadLinesAsync(path);
    }
}