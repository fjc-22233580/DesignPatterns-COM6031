using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocument : IDocument
{
    public void Open()
    {
    }

    public void Save()
    {
    }

    public void Print()
    {
    }

    public string Title { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }

    public List<string> Worksheets { get; } = new();
}