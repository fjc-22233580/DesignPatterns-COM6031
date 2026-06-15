using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocument : IDocument
{
    public List<string> Worksheets { get; } = new();

    public string Title { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }

}