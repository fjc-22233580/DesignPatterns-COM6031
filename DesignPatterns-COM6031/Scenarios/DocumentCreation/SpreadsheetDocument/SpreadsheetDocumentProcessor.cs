using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

/// <summary>
/// Concrete processor for applying spreadsheet-specific document processing rules.
/// </summary>
public class SpreadsheetDocumentProcessor : DocumentProcessor<SpreadsheetDocument>
{
    /// <summary>
    /// Validates that the spreadsheet has at least one worksheet before the shared processing steps continue.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the spreadsheet document does not contain any worksheets.
    /// </exception>
    protected override void Validate(SpreadsheetDocument document)
    {
        if (document.Worksheets.Any() == false)
        {
            throw new InvalidOperationException("Document is missing revisions.");
        }
    }
}