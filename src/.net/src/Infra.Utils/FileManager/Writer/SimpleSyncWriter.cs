using Domain.Contracts.Utils;
using Domain.Dto;
using Infra.Utils.FileManager.Extensions;

namespace Infra.Utils.FileManager.Writer;

public class SimpleSyncWriter : ISyncWriter
{
    /// <summary>
    /// Writes the provided measurements to a file at the specified path.
    /// </summary>
    /// <param name="path">The path of the file to write to. This argument must not be null.</param>
    /// <param name="measurements">The measurements to write to the file. This argument must not be null.</param>
    /// <returns>Returns true after successfully writing to the file.</returns>
    /// <exception cref="ArgumentException">Thrown when path or measurements is null.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
    public bool Write(string path, IDictionary<string, Measurement> measurements)
    {
        using var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        using var streamWriter = new StreamWriter(fileStream);
        var stringBuilder = measurements.ToStringBuilder();
        streamWriter.Write(stringBuilder.ToString());
        
        return true;
    }
}