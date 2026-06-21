using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

/// <summary>
/// Represents a Word document created and processed in the document creation scenario.
/// </summary>
public class WordDocument : IDocument
{
    /// <summary>
    /// Gets the revision history for the Word document.
    /// </summary>
    public List<string> Revisions { get; } = new();

    /// <summary>
    /// Gets or sets the document title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the main document content.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets the document footer.
    /// </summary>
    public string Footer { get; set; }
}