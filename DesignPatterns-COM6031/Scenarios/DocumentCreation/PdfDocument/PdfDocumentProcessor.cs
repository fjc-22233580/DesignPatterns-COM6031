using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocumentProcessor : DocumentProcessor<PdfDocument>
{
    protected override void Validate(PdfDocument document)
    {
        if (document.IsSigned == false)
        {
            throw new InvalidOperationException("PdfDocument is not signed");
        }
    }
}