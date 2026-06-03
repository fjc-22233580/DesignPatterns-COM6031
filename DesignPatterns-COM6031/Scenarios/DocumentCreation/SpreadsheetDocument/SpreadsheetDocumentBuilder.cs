using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentBuilder : DocumentBuilder<SpreadsheetDocumentBuilder>
{
    public SpreadsheetDocumentBuilder(IDocument document) : base(document)
    {
    }

    public SpreadsheetDocumentBuilder AddWorksheet(string worksheetName)
    {
        ((SpreadsheetDocument)_document).Worksheets.Add(worksheetName);
        return this;
    }
}