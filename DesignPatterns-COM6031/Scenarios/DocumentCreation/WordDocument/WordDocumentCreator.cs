namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

/// <summary>
/// Concrete creator responsible for creating Word document instances.
/// </summary>
public class WordDocumentCreator : DocumentCreator<WordDocument>
{
    /// <summary>
    /// Creates a new Word document.
    /// </summary>
    public override WordDocument CreateDocument()
    {
        return new WordDocument();
    }
}