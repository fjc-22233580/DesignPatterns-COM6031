using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.DocumentCreation;

public class DocumentCreationDemo : IDemo
{
    public string Name => nameof(DocumentCreationDemo);
    
    public void Run()
    {
        var running = true;
        
        // Define the menu options for the main menu.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Create Pdf", CreatePdf),
            new MenuItem("Create Doc", CreateDoc),
            new MenuItem("Create spreadsheet", CreateSpreadsheet),
            new MenuItem("Return to main menu", () => running = false)
        };

        while (running)
        {
            int menuIndex = ConsoleView.PrintSelectableMenu(Name, menuOptions.Select(x =>x.Title).ToList());
            menuOptions[menuIndex].Action();
        }
    }

    private void CreateSpreadsheet()
    {
        // Create spreadsheet document, builder, then build it
        var spreadsheetDocument = new SpreadsheetDocumentCreator().CreateDocument();
        var builder = new SpreadsheetDocumentBuilder(spreadsheetDocument);
        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("Spreadsheet Document")
            .AddWorksheet("New worksheet") // This specialization allows for adding worksheets. 
            .Build();
        
        // Process the document using the template workflow.
        // The PDF processor overrides the validate method to specialize that step. 
        var processor = new SpreadsheetDocumentProcessor();
        processor.ProcessDocument(spreadsheetDocument);
        
        ConsoleView.PrintDocument(Name, spreadsheetDocument);
    }


    private void CreatePdf()
    {
        // Create pdf document, builder, then build it
        var pdfDocument = new PdfDocumentCreator().CreateDocument();
        var builder = new PdfDocumentBuilder(pdfDocument);
        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("PDF Document")
            .Build();
                    
        // Process the document using the template workflow.
        // The PDF processor overrides the validate method to specialize that step. 
        var processor = new PdfDocumentProcessor();
        processor.ProcessDocument(pdfDocument);
        
        ConsoleView.PrintDocument(Name, pdfDocument);
    }
    
    private void CreateDoc()
    {
        // Create word document, builder, then build it
        var wordDocument = new WordDocumentCreator().CreateDocument();
        var builder = new WordDocumentBuilder(wordDocument);
        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("Document 15th Mar 2020 - J.Doe")
            .Build();
        
        // Process the document using the template workflow.
        // The Word processor overrides the save operation to store a revision date.
        var processor = new WordDocumentProcessor();
        processor.ProcessDocument(wordDocument);
        
        ConsoleView.PrintDocument(Name, wordDocument);
    }
}