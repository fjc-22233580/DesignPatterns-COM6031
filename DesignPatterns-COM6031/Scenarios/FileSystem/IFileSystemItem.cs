namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public interface IFileSystemItem
{
    string Name { get; }
    string Path { get; }
    long Size { get; }
}