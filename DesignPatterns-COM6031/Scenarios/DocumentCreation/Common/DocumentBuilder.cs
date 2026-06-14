namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public abstract class DocumentBuilder<TBuilder, TDocument> 
    where TBuilder : DocumentBuilder<TBuilder, TDocument> 
    where TDocument : IDocument
{
    protected readonly TDocument Document;
    
    protected DocumentBuilder(TDocument document)
    {
        Document = document;
    }
    
    public virtual TBuilder AddTitle(string title)
    {
        Document.Title = title;
        return (TBuilder)this;
    }

    public virtual TBuilder AddBody(string body)
    {
        Document.Body = body;
        return (TBuilder)this;
    }

    public virtual TBuilder AddFooter(string footer)
    {
        Document.Footer = footer;
        return (TBuilder)this;
    }

    public IDocument Build()
    {
        return Document;
    }
}