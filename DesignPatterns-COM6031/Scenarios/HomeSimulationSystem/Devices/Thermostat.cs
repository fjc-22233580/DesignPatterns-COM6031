using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

/// <summary>
/// Represents a smart thermostat receiver used by temperature commands and the smart home facade.
/// </summary>
public class Thermostat : ISmartDevice
{
    private const int RoomTemperature = 18;
    
    public Thermostat(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets the display name of the thermostat.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Gets the current thermostat temperature.
    /// </summary>
    public int Temperature { get; private set; } =  RoomTemperature;
    
    /// <summary>
    /// Increases the thermostat temperature by one degree.
    /// </summary>
    public string Increase()
    {
        Temperature++;
        return $"Temperature increased to: {Temperature}";
    }

    /// <summary>
    /// Decreases the thermostat temperature by one degree.
    /// </summary>
    public string Decrease()
    {
        Temperature--;
        return $"Temperature decreased: {Temperature}";
    }

    /// <summary>
    /// Sets the thermostat to a specific temperature.
    /// </summary>
    public string SetTemperature(int temperatureToSet)
    {
        Temperature = temperatureToSet;
        return $"Temperature set to: {Temperature}";
    }
}