using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem;

public class HomeSimulationDemo : IDemo
{
    private readonly RemoteControl _remote;
    private readonly Light _light;
    private readonly Thermostat _thermostat;
    private readonly DoorLock _frontDoor;
    private readonly SmartHomeFacade _smartHomeFacade;

    public HomeSimulationDemo()
    {
        _light = new Light("Living Room");
        _thermostat = new Thermostat("Airing Cupboard");
        _frontDoor = new DoorLock("Front Door");

        _smartHomeFacade = new SmartHomeFacade(_light, _thermostat, _frontDoor)
        {
            EveningTemperature = 22,
            AwayTemperature = 16,
        };

        _remote = new RemoteControl();
    }

    public string Name => "Home Simulation";

    public void Run()
    {
        bool running = true;

        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Turn light on",
                CreateMenuAction(() => new LightOnCommand(_light))),

            new MenuItem("Lock front door",
                CreateMenuAction(() => new DoorLockCommand(_frontDoor))),
            
            new MenuItem("Increase temperature",
                CreateMenuAction(() => new IncreaseTemperatureCommand(_thermostat))),
            
            new MenuItem("Decrease temperature",
                CreateMenuAction(() => new DecreaseTemperatureCommand(_thermostat))),

            new MenuItem("Set temperature to 22°C",
                CreateMenuAction(() => new SetTemperatureCommand(_thermostat, 22))),

            new MenuItem("Activate evening mode",
                CreateMenuAction(() => new EveningModeCommand(_smartHomeFacade))),

            new MenuItem("Activate away mode",
                CreateMenuAction(() => new AwayModeCommand(_smartHomeFacade))),

            new MenuItem("Undo previous command",
                () => ConsoleView.PrintMessage(Name, _remote.PressUndo())),

            new MenuItem("Return to previous menu",
                () => running = false),
        };

        // Print menu and wait for the user to respond.
        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuOptions[response].Action();
        }
    }
    
    /// <summary>
    /// Creates a menu action that constructs and executes a new command instance.
    ///
    /// A factory delegate is used so that each invocation creates a fresh
    /// command object. This ensures that any state cached by the command
    /// (for example, to support undo functionality) remains isolated to
    /// that specific execution.
    /// </summary>
    /// <param name="createCommand">
    /// A delegate that constructs the command to execute.
    /// </param>
    /// <returns>
    /// An <see cref="Action"/> suitable for use by a <see cref="MenuItem"/>.
    /// </returns>
    private Action CreateMenuAction(Func<ICommand> createCommand)
    {
        void ExecuteMenuAction()
        {
            // Instantiate the command
            ICommand command = createCommand();

            // Execute the command, then print the response
            string response = _remote.PressButton(command);
            ConsoleView.PrintMessage(Name, response);
        }

        return ExecuteMenuAction;
    }
}