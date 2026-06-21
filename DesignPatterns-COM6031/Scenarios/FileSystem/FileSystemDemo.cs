using System.Text;
using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.FileSystem;

/// <summary>
/// Demonstrates the file system scenario using Composite and Iterator patterns.
/// </summary>
public class FileSystemDemo : IDemo
{
    /// <summary>
    /// Gets the display name used in the main application menu.
    /// </summary>
    public string Name => "File system demo";

    /// <summary>
    /// Runs the file system scenario menu.
    /// </summary>
    public void Run()
    {
        bool running = true;

        // Each menu option runs a different version of the file system demonstration.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Print file system structure for test data (packaged with this exe).", CreateTestDataFileSystem),
            new MenuItem("Print sample file system structure.", CreateSampleFileSystem),
            new MenuItem("Return to previous menu", () => { running = false; }),
        };

        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuOptions[response].Action(); 
        }
    }

    /// <summary>
    /// Loads a real folder structure from the packaged test data and renders it to the console.
    /// </summary>
    private void CreateTestDataFileSystem()
    {
        const string testDataFolder = "TestData";
        var testDataPath = Path.Combine(AppContext.BaseDirectory, testDataFolder);

        // If the test data is missing, stop cleanly and show a message instead of throwing.
        if (!Directory.Exists(testDataPath))
        {
            ConsoleView.PrintMessage(Name, $"Cannot find test data folder, is it at the root of this exe?");
            return;
        }

        var sb = new StringBuilder();
        sb.AppendLine("Test data directory exists:");
        sb.AppendLine(testDataPath);
        sb.AppendLine();
        
        // The loader converts the real folder structure into the composite file system model.
        var root = FileSystemLoader.Load(testDataPath);

        // The renderer walks the structure through the directory iterator.
        var tree = FileSystemTreeRenderer.Render(root);
        
        sb.AppendLine("Test data file/directory structure:");
        sb.AppendLine();
        sb.AppendLine(tree);
        ConsoleView.PrintMessage(Name, sb.ToString());
    }

    /// <summary>
    /// Builds a sample file system structure in memory and renders it to the console.
    /// </summary>
    private void CreateSampleFileSystem()
    {
        // DirectoryItem can contain both files and other directories, demonstrating the Composite pattern.
        var root = new DirectoryItem("SampleProject", @"C:\SampleProject");

        var source = new DirectoryItem("src", @"C:\SampleProject\src");
        source.Add(new FileItem("Program.cs", @"C:\SampleProject\src\Program.cs", 4200));
        source.Add(new FileItem("FileSystemDemo.cs", @"C:\SampleProject\src\FileSystemDemo.cs", 7800));

        var docs = new DirectoryItem("docs", @"C:\SampleProject\docs");
        docs.Add(new FileItem("README.md", @"C:\SampleProject\docs\README.md", 2400));
        docs.Add(new FileItem("diagram.png", @"C:\SampleProject\docs\diagram.png", 185000));

        var tests = new DirectoryItem("tests", @"C:\SampleProject\tests");
        tests.Add(new FileItem("FileSystemTests.cs", @"C:\SampleProject\tests\FileSystemTests.cs", 6100));

        root.Add(source);
        root.Add(docs);
        root.Add(tests);
        root.Add(new FileItem("solution.sln", @"C:\SampleProject\solution.sln", 1200));

        var sb = new StringBuilder();
        sb.AppendLine("Sample in-memory file/directory structure:");
        sb.AppendLine();
        sb.AppendLine(FileSystemTreeRenderer.Render(root));

        ConsoleView.PrintMessage(Name, sb.ToString());
    }
}