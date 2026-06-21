using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

/// <summary>
/// Specialised builder for configuring Word documents.
/// </summary>
public class WordDocumentBuilder : DocumentBuilder<WordDocumentBuilder,  WordDocument>
{
    public WordDocumentBuilder(WordDocument document) : base(document)
    { }
    
    /// <summary>
    /// Adds a Word-specific revision entry to the document.
    /// </summary>
    public WordDocumentBuilder AddRevision(string revision)
    {
        Document.Revisions.Add($"{revision} Date: {DateTime.Now}");
        return this;
    }
}