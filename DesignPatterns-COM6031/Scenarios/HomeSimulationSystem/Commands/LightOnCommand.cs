using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }
    
    public string Execute()
    {
        return _light.TurnOn();
    }

    public string Undo()
    {
        return _light.TurnOff();
    }
}