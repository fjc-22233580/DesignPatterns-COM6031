using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that increases the thermostat temperature.
/// </summary>
public class IncreaseTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;

    public IncreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }

    /// <summary>
    /// Executes the temperature increase action on the thermostat receiver.
    /// </summary>
    public string Execute()
    {
        return _thermostat.Increase();
    }

    /// <summary>
    /// Undoes the command by decreasing the thermostat temperature.
    /// </summary>
    public string Undo()
    {
        return _thermostat.Decrease();
    }
}