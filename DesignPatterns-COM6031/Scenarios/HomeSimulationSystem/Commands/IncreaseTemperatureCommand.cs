using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class IncreaseTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;

    public IncreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }


    public string Execute()
    {
        return _thermostat.Increase();
    }

    public string Undo()
    {
        return _thermostat.Decrease();
    }
}