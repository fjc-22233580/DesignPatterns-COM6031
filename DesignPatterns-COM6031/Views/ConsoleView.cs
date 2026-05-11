namespace DesignPatterns_COM6031.Views;

public class ConsoleView
{
    private const int BoxWidth = 50;
        
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
    
    private static string Centre(string text, int width)
    {
        if (text.Length >= width)
            return text[..width];

        int leftPadding = (width + text.Length) / 2;
        return text.PadLeft(leftPadding).PadRight(width);
    }
    
    public static void PrintMessage(string title, string prompt)
    {
        PrintBox(title,prompt);
    }
    
    private static void PrintBox(string title, string body)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("┌" + new string('─', BoxWidth) + "┐");
        Console.WriteLine("│" + Centre(title, BoxWidth) + "│");
        Console.WriteLine("├" + new string('─', BoxWidth) + "┤");

        Console.WriteLine("│" + body.PadRight(BoxWidth) + "│");

        Console.WriteLine("├" + new string('─', BoxWidth) + "┤");
        Console.WriteLine("│" + "Press any key to return to menu".PadRight(BoxWidth) + "│");
        Console.WriteLine("└" + new string('─', BoxWidth) + "┘");
        Console.ReadKey(true);
    }
}