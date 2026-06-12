using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class DecreaseTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;

    public DecreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }
    
    public string Execute()
    {
        return _thermostat.Decrease();
    }

    public string Undo()
    {
        return _thermostat.Increase();
    }
}