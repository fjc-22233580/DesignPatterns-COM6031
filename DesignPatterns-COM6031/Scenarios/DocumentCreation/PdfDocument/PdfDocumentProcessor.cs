using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocumentProcessor : DocumentProcessor
{
    protected override void Validate(IDocument document)
    {
        Console.WriteLine("Validating PDF...");
    }
}