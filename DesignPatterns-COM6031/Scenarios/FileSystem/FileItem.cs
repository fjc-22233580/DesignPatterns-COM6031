namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public class FileItem : IFileSystemItem
{
    public FileItem(string name, string path, long size)
    {
        Name = name;
        Path = path;
        Size = size;
    }
    
    public string Name { get; }
    public string Path { get; }
    public long Size { get; }

    public override string ToString()
    {
        return $"- {Name} ({FileSizeFormatter.Format(Size)})";
    }
}