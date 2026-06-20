using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that turns the light on.
/// </summary>
public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }
    
    /// <summary>
    /// Executes the turn on action on the light receiver.
    /// </summary>
    public string Execute()
    {
        return _light.TurnOn();
    }

    /// <summary>
    /// Undoes the command by turning the light back off.
    /// </summary>
    public string Undo()
    {
        return _light.TurnOff();
    }
}