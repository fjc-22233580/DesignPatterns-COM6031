using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation;

public abstract class DocumentBuilder<TBuilder> where TBuilder : DocumentBuilder<TBuilder>
{
    protected readonly IDocument _document;
    
    protected DocumentBuilder(IDocument document)
    {
        _document = document;
    }
    
    public virtual TBuilder AddTitle(string title)
    {
        _document.Title = title;
        return (TBuilder)this;
    }

    public TBuilder AddBody(string body)
    {
        _document.Body = body;
        return (TBuilder)this;
    }

    public virtual TBuilder AddFooter(string footer)
    {
        _document.Footer = footer;
        return (TBuilder)this;
    }

    public IDocument Build()
    {
        return _document;
    }
}