using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}