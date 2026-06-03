using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;

public class SpreadsheetDocumentProcessor : DocumentProcessor
{
    protected override void Validate(IDocument document)
    {
        var spreadsheetDocument = (SpreadsheetDocument)document;

        if (spreadsheetDocument.Worksheets.Any() == false)
        {
            Console.WriteLine("Spreadsheet validation failed: document is empty!");
        }
        
        Console.WriteLine($"Spreadsheet validation passed: {spreadsheetDocument.Worksheets.Count}");
    }
}