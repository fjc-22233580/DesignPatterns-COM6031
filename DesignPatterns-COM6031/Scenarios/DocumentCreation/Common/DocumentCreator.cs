namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public abstract class DocumentCreator<TDocument> where TDocument : IDocument
{
    public abstract TDocument CreateDocument();
}