using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

public class Light : ISmartDevice
{
    public Light(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public bool IsLightOn {get; private set;}
    
    public string TurnOn()
    {
        IsLightOn = true;
        return "Light turned on";
    }

    public string TurnOff()
    {
        IsLightOn = false;
        return "Light turned off";
    }

    public void SetPower(bool isLightOn)
    {
        IsLightOn = isLightOn;
    }
}