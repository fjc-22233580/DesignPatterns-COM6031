using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that decreases the thermostat temperature.
/// </summary>
public class DecreaseTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;

    public DecreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }
    
    /// <summary>
    /// Executes the temperature decrease action on the thermostat receiver.
    /// </summary>
    public string Execute()
    {
        return _thermostat.Decrease();
    }

    /// <summary>
    /// Undoes the command by increasing the thermostat temperature.
    /// </summary>
    public string Undo()
    {
        return _thermostat.Increase();
    }
}