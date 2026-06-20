using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

/// <summary>
/// Represents a smart door lock receiver used by door lock commands and the smart home facade.
/// </summary>
public class DoorLock : ISmartDevice
{
    public DoorLock(string name)
    {
        Name = name;
    }
    
    /// <summary>
    /// Gets the display name of the door lock.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Gets or sets whether the door is currently locked.
    /// </summary>
    public bool IsLocked { get; set; }
    
    /// <summary>
    /// Locks the door.
    /// </summary>
    public string Lock()
    {
        IsLocked = true;
        return "Door locked";
    }

    /// <summary>
    /// Unlocks the door.
    /// </summary>
    public string Unlock()
    {
        IsLocked = false;
        return "Door unlocked";
    }

    /// <summary>
    /// Sets the locked state directly when restoring a previous smart home state.
    /// </summary>
    public void SetLocked(bool isLocked)
    {
        IsLocked = isLocked;
    }
}