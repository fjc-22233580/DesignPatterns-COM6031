using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Controllers;
using DesignPatterns_COM6031.Scenarios;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031;

class Program
{
    static void Main(string[] args)
    {
        var menuController = new MenuController();
        menuController.Run();
    }
}