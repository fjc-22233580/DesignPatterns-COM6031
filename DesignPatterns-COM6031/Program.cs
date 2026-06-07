using DesignPatterns_COM6031.Controllers;

namespace DesignPatterns_COM6031;

class Program
{
    static void Main(string[] args)
    {
        var menuController = new MenuController();
        menuController.Run();
    }
}