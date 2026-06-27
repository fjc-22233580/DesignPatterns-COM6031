using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem;

/// <summary>
/// Demonstrates the smart home scenario using Command and Facade patterns.
/// </summary>
public class HomeSimulationDemo : IDemo
{
    private readonly RemoteControl _remote;
    private readonly Light _light;
    private readonly Thermostat _thermostat;
    private readonly DoorLock _frontDoor;
    private readonly SmartHomeFacade _smartHomeFacade;

    public HomeSimulationDemo()
    {
        // Set up the smart home devices that act as command receivers.
        _light = new Light("Living Room");
        _thermostat = new Thermostat("Airing Cupboard");
        _frontDoor = new DoorLock("Front Door");

        // The facade coordinates multiple devices for higher-level modes.
        _smartHomeFacade = new SmartHomeFacade(_light, _thermostat, _frontDoor)
        {
            EveningTemperature = 22,
            AwayTemperature = 16,
        };

        // The remote control acts as the command invoker.
        _remote = new RemoteControl();
    }

    /// <summary>
    /// Gets the display name used in the main application menu.
    /// </summary>
    public string Name => "Home simulation demo";

    /// <summary>
    /// Runs the smart home scenario menu.
    /// </summary>
    public void Run()
    {
        bool running = true;

        // Each menu option creates a command which is then executed by the remote control.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Turn light on",
                CreateMenuAction(() => new LightOnCommand(_light))),
            
            new MenuItem("Turn light off",
                CreateMenuAction(() => new LightOffCommand(_light))),

            new MenuItem("Lock front door",
                CreateMenuAction(() => new LockDoorCommand(_frontDoor))),
            
            new MenuItem("Unlock front door",
                CreateMenuAction(() => new UnlockDoorCommand(_frontDoor))),
            
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

        while (running)
        {
            var menuItem = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuItem.Action();
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
            // Instantiate a fresh command for this menu selection.
            ICommand command = createCommand();

            // The remote invokes the command and stores it for undo.
            string response = _remote.PressButton(command);
            ConsoleView.PrintMessage(Name, response);
        }

        return ExecuteMenuAction;
    }
}