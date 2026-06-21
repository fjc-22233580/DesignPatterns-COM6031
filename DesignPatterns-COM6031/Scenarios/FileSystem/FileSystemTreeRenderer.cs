using System.Text;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Renders the file system object model as an indented text tree.
/// </summary>
public static class FileSystemTreeRenderer
{
    /// <summary>
    /// Renders the root file system item and all of its child items.
    /// </summary>
    public static string Render(IFileSystemItem root)
    {
        var builder = new StringBuilder();

        Render(root, builder, 0);

        return builder.ToString();
    }

    /// <summary>
    /// Recursively renders a file system item using indentation to show hierarchy.
    /// </summary>
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