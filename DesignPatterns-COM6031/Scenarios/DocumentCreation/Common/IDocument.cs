namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public interface IDocument
{
    void Open();
    void Save();
    void Print();
    
    string Title { get; set; }
    
    string Body { get; set; }
    
    string Footer { get; set; }
}