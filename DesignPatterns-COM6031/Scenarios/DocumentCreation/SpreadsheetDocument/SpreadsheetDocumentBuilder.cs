using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

/// <summary>
/// Specialised builder for configuring spreadsheet documents.
/// </summary>
public class SpreadsheetDocumentBuilder : DocumentBuilder<SpreadsheetDocumentBuilder, SpreadsheetDocument>
{
    public SpreadsheetDocumentBuilder(SpreadsheetDocument document) : base(document)
    { }

    /// <summary>
    /// Adds a spreadsheet-specific worksheet to the document.
    /// </summary>
    public SpreadsheetDocumentBuilder AddWorksheet(string worksheetName)
    {
        Document.Worksheets.Add(worksheetName);
        return this;
    }
}