using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;


public class SetTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;
    private readonly int _temperature;
    private int _previousTemperature;

    public SetTemperatureCommand(Thermostat thermostat, int temperature)
    {
        _thermostat = thermostat;
        _temperature = temperature;
    }
    
    public string Execute()
    {
        // Cache previous temperature
        _previousTemperature = _thermostat.Temperature;
        
        // Set new temperature
        return _thermostat.SetTemperature(_temperature);
    }

    public string Undo()
    {
        // User has chosen to undo - so set to cached value.
        return $"Temperature set back to: {_thermostat.SetTemperature(_previousTemperature)}";
    }
}