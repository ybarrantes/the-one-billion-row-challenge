using Domain.Contracts.Utils;
using FileNotFoundException = Infra.Utils.FileManager.Exceptions.FileNotFoundException;

namespace Infra.Utils.FileManager.Reader;

public class LineByLineSyncReader : ISyncReader
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
}