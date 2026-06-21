using System.Collections;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Represents a directory in the file system hierarchy.
/// </summary>
public class DirectoryItem : IFileSystemItem, IEnumerable<IFileSystemItem>
{
    private readonly List<IFileSystemItem> _children = new List<IFileSystemItem>();
    
    public DirectoryItem(string name, string path)
    {
        Name = name;
        Path = path;
    }

    /// <summary>
    /// Gets the directory name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the full directory path.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gets the total size of all child items in the directory.
    /// </summary>
    public long Size => _children.Sum(c => c.Size);

    /// <summary>
    /// Gets the total number of files contained in this directory and its child directories.
    /// </summary>
    public int FileCount => _children.Sum(child => child is DirectoryItem directory ? directory.FileCount : 1);
    
    /// <summary>
    /// Adds a file system item to the directory.
    /// </summary>
    public void Add(IFileSystemItem item)
    {
        _children.Add(item);
    }

    /// <summary>
    /// Removes a file system item from the directory.
    /// </summary>
    public void Remove(IFileSystemItem item)
    {
        _children.Remove(item);
    }
    
    /// <summary>
    /// Returns an iterator for the child items in this directory.
    /// </summary>
    public IEnumerator<IFileSystemItem> GetEnumerator()
    {
        return _children.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    /// <summary>
    /// Returns a formatted summary of the directory.
    /// </summary>
    public override string ToString()
    {
        return $"+ {Name} ({FileSizeFormatter.Format(Size)}) | Files: {FileCount}";
    }
}