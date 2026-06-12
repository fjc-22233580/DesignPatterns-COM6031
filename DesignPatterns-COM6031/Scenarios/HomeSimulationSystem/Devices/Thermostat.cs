using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

public class Thermostat : ISmartDevice
{
    private const int RoomTemperature = 18;
    
    public Thermostat(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public int Temperature { get; private set; } =  RoomTemperature;
    
    public string Increase()
    {
        Temperature++;
        return $"Temperature increased to: {Temperature}";
    }

    public string Decrease()
    {
        Temperature--;
        return $"Temperature decreased: {Temperature}";
    }

    public string SetTemperature(int temperatureToSet)
    {
        Temperature = temperatureToSet;
        return $"Temperature set to: {Temperature}";
    }
}