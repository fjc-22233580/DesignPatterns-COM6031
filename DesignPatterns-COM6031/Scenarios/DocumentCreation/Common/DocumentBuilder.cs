namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

/// <summary>
/// Base builder used to construct documents through a shared fluent interface.
/// </summary>
/// <typeparam name="TBuilder">
/// The concrete builder type returned from each fluent method.
/// </typeparam>
/// <typeparam name="TDocument">
/// The concrete document type being built.
/// </typeparam>
public abstract class DocumentBuilder<TBuilder, TDocument> 
    where TBuilder : DocumentBuilder<TBuilder, TDocument> 
    where TDocument : IDocument
{
    protected DocumentBuilder(TDocument document)
    {
        Document = document;
    }
    
    /// <summary>
    /// Gets the document instance being configured by the builder.
    /// </summary>
    protected TDocument Document { get; }
    
    /// <summary>
    /// Adds a title to the document and returns the concrete builder for chaining.
    /// </summary>
    public virtual TBuilder AddTitle(string title)
    {
        Document.Title = title;
        return (TBuilder)this;
    }

    /// <summary>
    /// Adds body content to the document and returns the concrete builder for chaining.
    /// </summary>
    public virtual TBuilder AddBody(string body)
    {
        Document.Body = body;
        return (TBuilder)this;
    }

    /// <summary>
    /// Adds a footer to the document and returns the concrete builder for chaining.
    /// </summary>
    public virtual TBuilder AddFooter(string footer)
    {
        Document.Footer = footer;
        return (TBuilder)this;
    }

    /// <summary>
    /// Returns the completed document.
    /// </summary>
    public IDocument Build()
    {
        return Document;
    }
}