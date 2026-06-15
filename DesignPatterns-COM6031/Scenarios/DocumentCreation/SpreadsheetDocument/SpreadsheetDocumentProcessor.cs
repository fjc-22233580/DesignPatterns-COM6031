using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentProcessor : DocumentProcessor<SpreadsheetDocument>
{
    protected override void Validate(SpreadsheetDocument document)
    {
        if (document.Worksheets.Any() == false)
        {
            throw new InvalidOperationException("Document is missing revisions.");
        }
    }
}