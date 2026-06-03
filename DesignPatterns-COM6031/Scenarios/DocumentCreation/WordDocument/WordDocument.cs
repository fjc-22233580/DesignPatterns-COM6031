using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocument : IDocument
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
    
    public List<string> Revisions { get; } = new();

    public string Title { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }
}