using System.Text;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public static class FileSystemTreeRenderer
{
    public static string Render(IFileSystemItem root)
    {
        var builder = new StringBuilder();

        Render(root, builder, 0);

        return builder.ToString();
    }

    private static void Render(IFileSystemItem item, StringBuilder builder, int indent)
    {
        builder.Append(' ', indent);
        builder.AppendLine(item.ToString());

        if (item is DirectoryItem directory)
        {
            foreach (var child in directory)
            {
                Render(child, builder, indent + 2);
            }
        }
    }
}