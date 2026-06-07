using System.Collections;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public class DirectoryItem : IFileSystemItem, IEnumerable<IFileSystemItem>
{
    private readonly List<IFileSystemItem> _children = new List<IFileSystemItem>();
    
    public DirectoryItem(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; }
    public string Path { get; }
    public long Size => _children.Sum(c => c.Size);
    public int FileCount => _children.Sum(child => child is DirectoryItem directory ? directory.FileCount : 1);
    
    public void Add(IFileSystemItem item)
    {
        _children.Add(item);
    }

    public void Remove(IFileSystemItem item)
    {
        _children.Remove(item);
    }
    
    public IEnumerator<IFileSystemItem> GetEnumerator()
    {
        return _children.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public override string ToString()
    {
        return $"+ {Name} ({FileSizeFormatter.Format(Size)}) | Files: {FileCount}";
    }
}