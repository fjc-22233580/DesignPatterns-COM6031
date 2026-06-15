using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocumentBuilder : DocumentBuilder<PdfDocumentBuilder, PdfDocument>
{
    public PdfDocumentBuilder(PdfDocument document) : base(document)
    {
        
    }

    public PdfDocumentBuilder SignPdf(bool isSigned)
    {
        Document.IsSigned = isSigned;
        return this;
    }

    public override PdfDocumentBuilder AddFooter(string footer)
    {
        footer += " | Generated as PDF";
        return base.AddFooter(footer);
    }
}