using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocumentCreator : DocumentCreator<WordDocument>
{
    public override WordDocument CreateDocument()
    {
        return new WordDocument();
    }
}