namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public static class FileSystemLoader
{
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