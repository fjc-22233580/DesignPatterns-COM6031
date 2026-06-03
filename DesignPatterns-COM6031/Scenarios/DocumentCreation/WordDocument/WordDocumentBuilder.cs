using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocumentBuilder : DocumentBuilder<WordDocumentBuilder>
{
    public WordDocumentBuilder(IDocument document) : base(document)
    {
        
    }
}