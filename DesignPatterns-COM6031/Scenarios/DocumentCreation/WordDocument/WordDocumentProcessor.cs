using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocumentProcessor : DocumentProcessor<WordDocument>
{
    protected override void Validate(WordDocument document)
    {
        if (document.Revisions.Any() == false)
        {
            throw new InvalidOperationException("Document is missing revisions.");
        }
    }

    protected override void Save(WordDocument document)
    {
        document.Revisions.Add($"Saved at {DateTime.Now}");
        base.Save(document);
    }
}