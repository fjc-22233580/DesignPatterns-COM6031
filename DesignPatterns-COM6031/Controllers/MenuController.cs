using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.DocumentCreation;
using DesignPatterns_COM6031.Scenarios.FileSystem;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Controllers;

/// <summary>
/// Controls the main console menu for selecting and running each scenario demo.
/// </summary>
public class MenuController
{
    private const string Name = "Design Patterns App - COM6031";

    /// <summary>
    /// Runs the menu loop until the user selects the exit option.
    /// </summary>
    public void Run()
    {
        var demos = new List<IDemo>
        {
            new DocumentCreationDemo(),
            new SupportTicketSystemDemo(),
            new FileSystemDemo(),
            new HomeSimulationDemo()
        };

        var menuOptions = demos
            .Select(demo => new MenuItem(demo.Name, demo.Run))
            .Append(new MenuItem("Exit", () => Environment.Exit(0)))
            .ToList();

        while (true) // No need to end this loop as there is a menu option which closes the application.
        {
            var menuItem = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuItem.Action();
        }
    }
}