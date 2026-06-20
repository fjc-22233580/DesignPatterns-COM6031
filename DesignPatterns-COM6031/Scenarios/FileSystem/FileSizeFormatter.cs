namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Provides helper methods for displaying file sizes in a readable format.
/// </summary>
public static class FileSizeFormatter
{
    /// <summary>
    /// Converts a size in bytes into the most appropriate display unit.
    /// </summary>
    public static string Format(long bytes)
    {
        const double kb = 1024;
        const double mb = kb * 1024;
        const double gb = mb * 1024;

        return bytes switch
        {
            >= (long)gb => $"{bytes / gb:F2} GB",
            >= (long)mb => $"{bytes / mb:F2} MB",
            >= (long)kb => $"{bytes / kb:F2} KB",
            _ => $"{bytes} B"
        };
    }
}