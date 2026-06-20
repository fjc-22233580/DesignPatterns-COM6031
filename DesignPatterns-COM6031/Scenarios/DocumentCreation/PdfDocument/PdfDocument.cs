using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

/// <summary>
/// Represents a specialised document type with PDF-specific signing state.
/// </summary>
public class PdfDocument : IDocument
{
    /// <summary>
    /// Gets or sets whether the PDF document has been signed.
    /// </summary>
    public bool IsSigned { get; set; }
    
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