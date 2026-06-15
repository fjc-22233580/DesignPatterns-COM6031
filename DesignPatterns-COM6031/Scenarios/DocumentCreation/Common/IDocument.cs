namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public interface IDocument
{
    string Title { get; set; }
    
    string Body { get; set; }
    
    string Footer { get; set; }
}