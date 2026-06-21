namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

/// <summary>
/// Concrete creator responsible for creating PDF document instances.
/// </summary>
public class PdfDocumentCreator : DocumentCreator<PdfDocument>
{
    /// <summary>
    /// Creates a new PDF document.
    /// </summary>
    public override PdfDocument CreateDocument()
    {
        return new PdfDocument();
    }
}