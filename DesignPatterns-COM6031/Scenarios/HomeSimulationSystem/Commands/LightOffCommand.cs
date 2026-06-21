using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that turns the light off.
/// </summary>
public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }
    
    /// <summary>
    /// Executes the turn off action on the light receiver.
    /// </summary>
    public string Execute()
    {
        return _light.TurnOff();
    }

    /// <summary>
    /// Undoes the command by turning the light back on.
    /// </summary>
    public string Undo()
    {
        return _light.TurnOn();
    }
    
}