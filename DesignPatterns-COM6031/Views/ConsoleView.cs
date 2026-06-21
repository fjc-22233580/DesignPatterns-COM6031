using System.Text;
using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.PdfDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.SpreadsheetDocument;
using DesignPatterns_COM6031.Scenarios.DocumentCreation.WordDocument;

namespace DesignPatterns_COM6031.Views;

/// <summary>
/// Provides shared console output methods used by the scenario demonstrations.
/// </summary>
public static class ConsoleView
{
    private const int BoxWidth = 80;

    /// <summary>
    /// Prints a selectable console menu and returns the index of the selected item.
    /// </summary>
    public static int PrintSelectableMenu(string title, List<MenuItem> items)
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
                    ? $"  {menuNumber}. {items[i].Title}  "
                    : $"  {menuNumber}. {items[i].Title}";

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

    /// <summary>
    /// Prints the common document fields, along with any document-specific details.
    /// </summary>
    public static void PrintDocument(string title, IDocument document)
    {
        var sb = new StringBuilder();
        sb.AppendLine("=========================");
        sb.AppendLine($"Type: {document.GetType().Name}");
        sb.AppendLine("=========================");
        sb.AppendLine();
        sb.AppendLine($"Title: {document.Title}");
        sb.AppendLine($"Body: {document.Body}");
        sb.AppendLine($"Footer: {document.Footer}");

        switch (document)
        {
            case SpreadsheetDocument spreadsheet:
            {
                sb.AppendLine();
                sb.AppendLine("Worksheets:");
            
                foreach (var spreadsheetWorksheet in spreadsheet.Worksheets)
                {
                    sb.AppendLine(spreadsheetWorksheet);
                }

                break;
            }
            case WordDocument wordDocument:
            {
                sb.AppendLine();
                sb.AppendLine("Revisions:");
            
                foreach (var wordDocumentRevision in wordDocument.Revisions)
                {
                    sb.AppendLine(wordDocumentRevision);
                }

                break;
            }
            case PdfDocument pdfDocument:
            {
                sb.AppendLine();
                sb.AppendLine($"E-sign status: {pdfDocument.IsSigned}");

                break;
            }
                
        }
        
        PrintBox(title, sb.ToString());
    }

    /// <summary>
    /// Prints a simple message inside the standard console box layout.
    /// </summary>
    public static void PrintMessage(string title, string prompt)
    {
        PrintBox(title, prompt);
    }

    /// <summary>
    /// Prints boxed console output with a title, wrapped body text, and return prompt.
    /// </summary>
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

    /// <summary>
    /// Centres text within a fixed-width console line.
    /// </summary>
    private static string Centre(string text, int width)
    {
        if (text.Length >= width)
            return text[..width];

        int leftPadding = (width + text.Length) / 2;
        return text.PadLeft(leftPadding).PadRight(width);
    }

}