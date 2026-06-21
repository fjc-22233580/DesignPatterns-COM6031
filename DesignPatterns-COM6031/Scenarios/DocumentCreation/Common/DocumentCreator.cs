using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

/// <summary>
/// Base creator for producing a specific type of document.
/// </summary>
/// <typeparam name="TDocument">
/// The document type created by this creator.
/// </typeparam>
public abstract class DocumentCreator<TDocument> where TDocument : IDocument
{
    /// <summary>
    /// Creates a new document instance.
    /// </summary>
    public abstract TDocument CreateDocument();
}