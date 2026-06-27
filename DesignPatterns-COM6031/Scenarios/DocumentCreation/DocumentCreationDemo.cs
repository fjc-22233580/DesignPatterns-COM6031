using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation;

/// <summary>
/// Demonstrates document creation using Factory Method, Builder, and Template Method patterns.
/// </summary>
public class DocumentCreationDemo : IDemo
{
    /// <summary>
    /// Gets the display name used in the main application menu.
    /// </summary>
    public string Name => "Document creation demo";
    
    /// <summary>
    /// Runs the document creation scenario menu.
    /// </summary>
    public void Run()
    {
        var running = true;
        
        // Each menu item maps a user-facing option to one document creation demonstration.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Create Pdf document", CreatePdf),
            new MenuItem("Create Word document", CreateWordDoc),
            new MenuItem("Create spreadsheet document", CreateSpreadsheet),
            new MenuItem("Return to main menu", () => running = false)
        };

        while (running)
        {
            var menuItem = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuItem.Action();
        }
    }

    /// <summary>
    /// Demonstrates creating, building, and processing a spreadsheet document.
    /// </summary>
    private void CreateSpreadsheet()
    {
        // Factory Method creates the concrete document while the client works through a creator.
        var spreadsheetDocument = new SpreadsheetDocumentCreator().CreateDocument(); // Factory

        // Builder adds common document fields and spreadsheet-specific worksheet data.
        var builder = new SpreadsheetDocumentBuilder(spreadsheetDocument); // Builder
        builder
            .AddTitle("Budget Summary")
            .AddBody("Quarterly budget overview.")
            .AddFooter("Finance Department")
            .AddWorksheet("Q1 Budget") // Builder specialisation for spreadsheet documents.
            .AddWorksheet("Q2 Budget")
            .Build();
        
        // Template Method runs the fixed processing workflow.
        // The spreadsheet processor provides its own validation rule.
        var processor = new SpreadsheetDocumentProcessor(); // Template
        processor.ProcessDocument(spreadsheetDocument);
        
        ConsoleView.PrintDocument(Name, spreadsheetDocument);
    }

    /// <summary>
    /// Demonstrates creating, building, and processing a PDF document.
    /// </summary>
    private void CreatePdf()
    {
        // Factory Method creates the concrete document while the client works through a creator.
        var pdfDocument = new PdfDocumentCreator().CreateDocument();

        // Builder adds common document fields and PDF-specific signing state.
        var builder = new PdfDocumentBuilder(pdfDocument);
        builder
            .AddTitle("Monthly Report")
            .AddBody("Performance overview for April.")
            .AddFooter("PDF Export")
            .SignPdf(isSigned: true)
            .Build();
                    
        // Template Method runs the fixed processing workflow.
        // The PDF processor provides its own validation rule.
        var processor = new PdfDocumentProcessor();
        processor.ProcessDocument(pdfDocument);
        
        ConsoleView.PrintDocument(Name, pdfDocument);
    }
    
    /// <summary>
    /// Demonstrates creating, building, and processing a Word document.
    /// </summary>
    private void CreateWordDoc()
    {
        // Factory Method creates the concrete document while the client works through a creator.
        var wordDocument = new WordDocumentCreator().CreateDocument(); // Factory

        // Builder adds common document fields and Word-specific revision data.
        var builder = new WordDocumentBuilder(wordDocument); // Builder
        builder
            .AddTitle("Meeting Notes")
            .AddBody("Actions agreed during the team meeting.")
            .AddFooter("Revised 15th Mar 2020 - J.Doe")
            .AddRevision("First draft complete.") // Builder specialisation for Word documents.
            .Build();
        
        // Template Method runs the fixed processing workflow.
        // The Word processor overrides the save step to add a revision entry.
        var processor = new WordDocumentProcessor(); // Template method
        processor.ProcessDocument(wordDocument);
        
        ConsoleView.PrintDocument(Name, wordDocument);
    }
}