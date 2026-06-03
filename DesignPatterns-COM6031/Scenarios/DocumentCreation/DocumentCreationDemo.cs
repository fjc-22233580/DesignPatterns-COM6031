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
        var  creator = new SpreadsheetDocumentCreator();
        var document = creator.CreateDocument();
        
        var builder = new SpreadsheetDocumentBuilder(document);
        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("Spreadsheet Document")
            .AddWorksheet("New worksheet") 
            .Build();
        
        var processor = new SpreadsheetDocumentProcessor();
        processor.ProcessDocument(document);
        
        ConsoleView.PrintDocument(Name, document);
    }


    private void CreatePdf()
    {
        var creator = new PdfDocumentCreator();
        var document = creator.CreateDocument();
                    
        var builder = new PdfDocumentBuilder(document);

        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("PDF Document")
            .Build();
                    
        var processor = new PdfDocumentProcessor();

        processor.ProcessDocument(document);
        ConsoleView.PrintDocument(Name, document);
    }
    
    private void CreateDoc()
    {
        var creator = new WordDocumentCreator();
        var document = creator.CreateDocument();
        
        var builder = new WordDocumentBuilder(document);
        
        builder
            .AddTitle("Example Document")
            .AddBody("Document content")
            .AddFooter("Word Document")
            .Build();
        
        var processor = new WordDocumentProcessor();
        processor.ProcessDocument(document);
        
        ConsoleView.PrintDocument(Name, document);
    }
}