using DesignPatterns_COM6031.Controllers;

namespace DesignPatterns_COM6031;

/// <summary>
/// Application entry point for running the design pattern scenario demonstrations.
/// </summary>
class Program
{
    /// <summary>
    /// Creates the main menu controller and starts the console demonstration.
    /// </summary>
    static void Main(string[] args)
    {
        new MenuController().Run();
    }
}