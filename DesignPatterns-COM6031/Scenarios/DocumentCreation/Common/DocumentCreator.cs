namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public abstract class DocumentCreator
{
    public void ProcessDocument()
    {
        var document = CreateDocument();

        document.Open();
        document.Save();
        document.Print();
    }
    
    public abstract IDocument CreateDocument();
}