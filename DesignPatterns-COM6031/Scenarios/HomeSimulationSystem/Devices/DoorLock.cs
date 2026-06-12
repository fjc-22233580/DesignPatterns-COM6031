using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

public class DoorLock : ISmartDevice
{
    public DoorLock(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
    
    public bool IsLocked { get; set; }
    
    public string Lock()
    {
        IsLocked = true;
        return "Door locked";
    }

    public string Unlock()
    {
        IsLocked = false;
        return "Door unlocked";
    }

    public void SetLocked(bool isLocked)
    {
       IsLocked = isLocked;
    }
}