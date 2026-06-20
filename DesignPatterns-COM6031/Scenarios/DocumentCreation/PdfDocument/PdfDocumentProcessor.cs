using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

/// <summary>
/// Concrete processor for applying PDF-specific document processing rules.
/// </summary>
public class PdfDocumentProcessor : DocumentProcessor<PdfDocument>
{
    /// <summary>
    /// Validates that the PDF has been signed before the shared processing steps continue.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the PDF document has not been signed.
    /// </exception>
    protected override void Validate(PdfDocument document)
    {
        if (document.IsSigned == false)
        {
            throw new InvalidOperationException("PdfDocument is not signed");
        }
    }
}