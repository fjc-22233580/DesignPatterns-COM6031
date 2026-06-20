using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

/// <summary>
/// Concrete processor for applying Word-specific document processing rules.
/// </summary>
public class WordDocumentProcessor : DocumentProcessor<WordDocument>
{
    /// <summary>
    /// Validates that the Word document has revision history before the shared processing steps continue.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the Word document does not contain any revisions.
    /// </exception>
    protected override void Validate(WordDocument document)
    {
        if (document.Revisions.Any() == false)
        {
            throw new InvalidOperationException("Document is missing revisions.");
        }
    }

    /// <summary>
    /// Saves the Word document and records the save action in the document revision history.
    /// </summary>
    protected override void Save(WordDocument document)
    {
        document.Revisions.Add($"Saved at {DateTime.Now}");
        base.Save(document);
    }
}