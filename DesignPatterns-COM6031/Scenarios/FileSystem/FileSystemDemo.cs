using System.Text;
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
            new MenuItem("Print file system structure for test data (packaged with this exe).", CreateTestDataFileSystem),
            new MenuItem("Return to previous menu", () => { running = false; }),
        };

        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuOptions[response].Action();
        }
    }

    private void CreateTestDataFileSystem()
    {
        const string testDataFolder = "TestData";
        var testDataPath = Path.Combine(AppContext.BaseDirectory, testDataFolder);

        // Could not find test data path - bail out.
        if (!Directory.Exists(testDataPath))
        {
            ConsoleView.PrintMessage(Name, $"Cannot find test data folder, is it at the root as the exe?");
            return;
        }

        // We have found the test data directory
        var sb = new StringBuilder();
        sb.AppendLine("Test data directory exists:");
        sb.AppendLine(testDataPath);
        sb.AppendLine();

        // Load the file system structure and print it out
        var root = FileSystemLoader.Load(testDataPath);
        var tree = FileSystemTreeRenderer.Render(root);
        sb.AppendLine(tree);
        ConsoleView.PrintMessage(Name, sb.ToString());
    }
}