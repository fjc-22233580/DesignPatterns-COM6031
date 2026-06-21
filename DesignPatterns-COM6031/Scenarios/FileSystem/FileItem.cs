namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Represents a file in the file system hierarchy.
/// </summary>
public class FileItem : IFileSystemItem
{
    public FileItem(string name, string path, long size)
    {
        Name = name;
        Path = path;
        Size = size;
    }
    
    /// <summary>
    /// Gets the file name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the full file path.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gets the file size in bytes.
    /// </summary>
    public long Size { get; }

    /// <summary>
    /// Returns a formatted summary of the file.
    /// </summary>
    public override string ToString()
    {
        return $"- {Name} ({FileSizeFormatter.Format(Size)})";
    }
}