namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

/// <summary>
/// Concrete creator responsible for creating spreadsheet document instances.
/// </summary>
public class SpreadsheetDocumentCreator : DocumentCreator<SpreadsheetDocument>
{
    /// <summary>
    /// Creates a new spreadsheet document.
    /// </summary>
    public override SpreadsheetDocument CreateDocument()
    {
        return new SpreadsheetDocument();
    }
}