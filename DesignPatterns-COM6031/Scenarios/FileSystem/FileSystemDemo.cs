using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

public class FileSystemDemo : IDemo
{
    public string Name => nameof(FileSystemDemo);
    public void Run()
    {
        bool running = true;
        
        // Define the menu options for the main menu.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Crate file system demo", CreateFileSystem),
            new MenuItem("Return to previous menu", () => { running = false; }),
        };

        var stringMenu = menuOptions.Select(x => x.Title).ToList();
        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, stringMenu);
            menuOptions[response].Action();
        }
    }

    private void CreateFileSystem()
    {
        var file = Path.Combine(AppContext.BaseDirectory, "TestData","TestDocument.txt");

        if (File.Exists(file))
        {
            var fileInfo = new FileInfo(file);
            
            ConsoleView.PrintMessage(Name, $"Test document exists: Path: {fileInfo.Directory} {fileInfo.Length} bytes");
            
        }
        else
        {
            ConsoleView.PrintMessage(Name, $"Cannot find test document");
            
        }
        
    }
}