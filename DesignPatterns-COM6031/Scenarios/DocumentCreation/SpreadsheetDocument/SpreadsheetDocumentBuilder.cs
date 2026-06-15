using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentBuilder : DocumentBuilder<SpreadsheetDocumentBuilder, SpreadsheetDocument>
{
    public SpreadsheetDocumentBuilder(SpreadsheetDocument document) : base(document)
    {
    }

    public SpreadsheetDocumentBuilder AddWorksheet(string worksheetName)
    {
        Document.Worksheets.Add(worksheetName);
        return this;
    }
}