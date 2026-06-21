using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

/// <summary>
/// Represents a specialised spreadsheet document created and processed in the document creation scenario.
/// </summary>
public class SpreadsheetDocument : IDocument
{
    /// <summary>
    /// Gets the worksheets contained within the spreadsheet document.
    /// </summary>
    public List<string> Worksheets { get; } = new();

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