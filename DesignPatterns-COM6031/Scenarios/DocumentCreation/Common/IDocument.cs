namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

/// <summary>
/// Defines the common document fields used by each document type.
/// </summary>
public interface IDocument
{
    /// <summary>
    /// Gets or sets the document title.
    /// </summary>
    string Title { get; set; }
    
    /// <summary>
    /// Gets or sets the main document content.
    /// </summary>
    string Body { get; set; }
    
    /// <summary>
    /// Gets or sets the document footer.
    /// </summary>
    string Footer { get; set; }
}