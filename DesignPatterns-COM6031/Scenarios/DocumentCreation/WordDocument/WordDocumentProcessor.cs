using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

public class WordDocumentProcessor : DocumentProcessor
{
    protected override void Validate(IDocument document)
    {
        Console.WriteLine("Validating Word Document...");
    }

    protected override void Save(IDocument document)
    {
        ((WordDocument)document).Revisions.Add($"Saved at {DateTime.Now}");
        base.Save(document);
    }
}