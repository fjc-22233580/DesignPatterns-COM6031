namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Creates the file system object model from a real directory path.
/// In this context, it loads a folder of test data which is packaged with this exe.
/// </summary>
public static class FileSystemLoader
{
    /// <summary>
    /// Recursively loads a directory and its contents into the composite file system structure.
    /// </summary>
    public static DirectoryItem Load(string path)
    {
        var directoryInfo = new DirectoryInfo(path);

        var directory = new DirectoryItem(directoryInfo.Name, directoryInfo.FullName);

        foreach (var file in directoryInfo.GetFiles())
        {
            directory.Add(new FileItem(file.Name, file.FullName, file.Length));
        }

        foreach (var subDirectory in directoryInfo.GetDirectories())
        {
            directory.Add(Load(subDirectory.FullName));
        }

        return directory;
    }
}