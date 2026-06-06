using System.Text;
using DesignPatterns_COM6031.Scenarios.DocumentCreation;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Ticket;

namespace DesignPatterns_COM6031.Views;

public class ConsoleView
{
    private const int BoxWidth = 80;

    public static int PrintSelectableMenu(string title, List<string> items)
    {
        int selectedIndex = 0;
        bool inMenu = true;
        ConsoleKey key;
        Console.Clear();

        while (inMenu)
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("┌" + new string('─', BoxWidth) + "┐");
            Console.WriteLine("│" + Centre(title, BoxWidth) + "│");
            Console.WriteLine("├" + new string('─', BoxWidth) + "┤");

            for (int i = 0; i < items.Count; i++)
            {
                bool selected = i == selectedIndex;
                int menuNumber = i + 1;

                Console.Write("│");

                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                string line = selected
                    ? $"  {menuNumber}. {items[i]}  "
                    : $"  {menuNumber}. {items[i]}";

                Console.Write(line.PadRight(BoxWidth));
                Console.ResetColor();
                Console.WriteLine("│");
            }

            Console.WriteLine("├" + new string('─', BoxWidth) + "┤");
            Console.WriteLine("│" + "Use W/S or Up/Down, Enter to select".PadRight(BoxWidth) + "│");
            Console.WriteLine("└" + new string('─', BoxWidth) + "┘");

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex + 1) % items.Count;
                    break;
                case ConsoleKey.Enter:
                    inMenu = false;
                    break;
            }
        }

        return selectedIndex;
    }
    
    
    public static void PrintTicket(string title, Ticket ticket)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ticket.Title);
        sb.AppendLine(ticket.Description);
        sb.AppendLine(ticket.CreatedDate.ToShortDateString());
        sb.AppendLine(ticket.Priority.ToString());
        sb.AppendLine(ticket.Category.ToString());
        
        PrintBox(title, sb.ToString());
    }


    public static void PrintDocument(string title, IDocument document)
    {
        var sb = new StringBuilder();
        sb.AppendLine(document.Title);
        sb.AppendLine(document.Body);
        sb.AppendLine(document.Footer);
        
        PrintBox(title, sb.ToString());
    }

    public static void PrintMessage(string title, string prompt)
    {
        PrintBox(title, prompt);
    }

    private static void PrintBox(string title, string body)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("┌" + new string('─', BoxWidth) + "┐");
        Console.WriteLine("│" + Centre(title, BoxWidth) + "│");
        Console.WriteLine("├" + new string('─', BoxWidth) + "┤");

        foreach (string inputLine in body.Split(Environment.NewLine))
        {
            // Preserve empty lines
            if (string.IsNullOrEmpty(inputLine))
            {
                Console.WriteLine("│" + new string(' ', BoxWidth) + "│");
                continue;
            }

            int currentIndex = 0;

            // Wrap long lines
            while (currentIndex < inputLine.Length)
            {
                int remainingLength = inputLine.Length - currentIndex;
                int chunkLength = Math.Min(BoxWidth, remainingLength);

                string chunk = inputLine.Substring(currentIndex, chunkLength);

                Console.WriteLine("│" + chunk.PadRight(BoxWidth) + "│");

                currentIndex += chunkLength;
            }
        }

        Console.WriteLine("├" + new string('─', BoxWidth) + "┤");
        Console.WriteLine("│" + "Press any key to return to menu".PadRight(BoxWidth) + "│");
        Console.WriteLine("└" + new string('─', BoxWidth) + "┘");

        Console.ReadKey(true);
    }


    private static string Centre(string text, int width)
    {
        if (text.Length >= width)
            return text[..width];

        int leftPadding = (width + text.Length) / 2;
        return text.PadLeft(leftPadding).PadRight(width);
    }

}