using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Controllers;

public class MenuController
{
    private const string Name = "Design Patterns App - COM6031";

    private readonly List<MenuItem> _menuOptions;
    
    public MenuController()
    {
        var demos = new List<IDemo>
        {
            new DocumentCreationDemo(),
            new SupportTicketSystemDemo()
        };

        _menuOptions = demos
            .Select(demo => new MenuItem(demo.Name, demo.Run))
            .Append(new MenuItem("Exit", () => Environment.Exit(0)))
            .ToList();
    }

    public void Run()
    {
        while (true)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, _menuOptions.Select(x =>x.Title).ToList());
            _menuOptions[response].Action();
        }
    }
}