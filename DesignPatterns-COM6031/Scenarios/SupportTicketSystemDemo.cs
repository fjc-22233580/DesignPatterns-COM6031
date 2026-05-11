using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios;

public class SupportTicketSystemDemo : IDemo
{
    public string Name => nameof(SupportTicketSystemDemo);
    
    public void Run()
    {
        // Define the menu options for the main menu.
        var _menuOptions = new List<string>
        {
            "Raise ticket",
            "Check ticket",
            "Return to main menu"
        };

        var running = true;
        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, _menuOptions);
            switch (response)
            {
                case 0:
                    ConsoleView.PrintMessage(Name,"Ticket raised");
                    break;
                case 1:
                    ConsoleView.PrintMessage(Name, "Ticket found");
                    break;
                case 2:
                    running = false;
                    break;
            }
        }
    }
}