namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public abstract class DocumentProcessor<TDocument> where TDocument : IDocument
{
    public void ProcessDocument(TDocument document)
    {
        Validate(document);
        Save(document);
        Print(document);
    }

   
    protected abstract void Validate(TDocument document);

    protected virtual void Save(TDocument document)
    {
        // Document Saved
    }

    protected virtual void Print(TDocument document)
    {
        // Document Printed
    }
}