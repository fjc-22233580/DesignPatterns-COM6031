using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

/// <summary>
/// Represents a smart light receiver used by light commands and the smart home facade.
/// </summary>
public class Light : ISmartDevice
{
    public Light(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets the display name of the light.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Gets whether the light is currently turned on.
    /// </summary>
    public bool IsLightOn {get; private set;}
    
    /// <summary>
    /// Turns the light on.
    /// </summary>
    public string TurnOn()
    {
        IsLightOn = true;
        return "Light turned on";
    }

    /// <summary>
    /// Turns the light off.
    /// </summary>
    public string TurnOff()
    {
        IsLightOn = false;
        return "Light turned off";
    }

    /// <summary>
    /// Sets the light power state directly when restoring a previous smart home state.
    /// </summary>
    public void SetPower(bool isLightOn)
    {
        IsLightOn = isLightOn;
    }
}