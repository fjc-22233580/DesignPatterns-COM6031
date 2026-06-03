using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new SpreadsheetDocument();
    }
}