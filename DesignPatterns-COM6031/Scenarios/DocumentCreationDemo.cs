using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios;

public class DocumentCreationDemo : IDemo
{
    public string Name => nameof(DocumentCreationDemo);
    
    public void Run()
    {
        // Define the menu options for the main menu.
        var _menuOptions = new List<string>
        {
            "Create PDF",
            "Create Doc",
            "Return to main menu"
        };

        var running = true;
        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, _menuOptions);
            switch (response)
            {
                case 0:
                    ConsoleView.PrintMessage(Name,"Created PDF");
                    break;
                case 1:
                    ConsoleView.PrintMessage(Name, "Created Doc");
                    break;
                case 2:
                    running = false;
                    break;
            }
        }
    }
}