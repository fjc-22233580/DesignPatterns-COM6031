using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;

public class PdfDocument : IDocument
{
    public bool IsSigned { get; set; }
    
    public string Title { get; set; }
    
    public string Body { get; set; }
    
    public string Footer { get; set; }
}