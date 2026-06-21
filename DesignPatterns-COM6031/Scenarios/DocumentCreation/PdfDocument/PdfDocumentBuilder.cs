using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

/// <summary>
/// Specialised builder for configuring PDF documents.
/// </summary>
public class PdfDocumentBuilder : DocumentBuilder<PdfDocumentBuilder, PdfDocument>
{
    public PdfDocumentBuilder(PdfDocument document) : base(document)
    { }

    /// <summary>
    /// Adds PDF-specific signing state to the document.
    /// </summary>
    public PdfDocumentBuilder SignPdf(bool isSigned)
    {
        Document.IsSigned = isSigned;
        return this;
    }

    /// <summary>
    /// Adds a footer with additional PDF-specific output text.
    /// </summary>
    public override PdfDocumentBuilder AddFooter(string footer)
    {
        footer += " | Generated as PDF";
        return base.AddFooter(footer);
    }
}