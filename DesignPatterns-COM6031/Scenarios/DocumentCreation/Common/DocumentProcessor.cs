namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public abstract class DocumentProcessor
{
    public void ProcessDocument(IDocument document)
    {
        Validate(document);
        Save(document);
        Print(document);
    }

    protected abstract void Validate(IDocument document);

    protected virtual void Save(IDocument document)
    {
        document.Save();
    }

    protected virtual void Print(IDocument document)
    {
        document.Print();
    }
}