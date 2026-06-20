namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Defines the common interface for files and directories in the file system hierarchy.
/// </summary>
public interface IFileSystemItem
{
    /// <summary>
    /// Gets the file system item name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the full file system item path.
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Gets the size of the file system item in bytes.
    /// </summary>
    long Size { get; }
}