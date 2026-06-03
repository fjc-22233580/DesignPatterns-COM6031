using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocumentBuilder : DocumentBuilder<PdfDocumentBuilder>
{
    public PdfDocumentBuilder(IDocument document) : base(document)
    {
        
    }

    public override PdfDocumentBuilder AddFooter(string footer)
    {
        footer += " | Generated as PDF";
        return base.AddFooter(footer);
    }
}