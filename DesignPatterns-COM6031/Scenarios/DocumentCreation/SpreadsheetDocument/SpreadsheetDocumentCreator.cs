using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentCreator : DocumentCreator<SpreadsheetDocument>
{
    public override SpreadsheetDocument CreateDocument()
    {
        return new SpreadsheetDocument();
    }
}