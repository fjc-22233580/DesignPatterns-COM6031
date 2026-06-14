using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocumentBuilder : DocumentBuilder<WordDocumentBuilder,  WordDocument>
{
    public WordDocumentBuilder(WordDocument document) : base(document)
    {
        
    }
}