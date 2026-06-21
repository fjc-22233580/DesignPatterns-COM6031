using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that locks the door.
/// </summary>
public class DoorLockCommand : ICommand
{
    private readonly DoorLock _doorLock;

    public DoorLockCommand(DoorLock doorLock)
    {
        _doorLock = doorLock;
    }
    
    /// <summary>
    /// Executes the lock action on the door lock receiver.
    /// </summary>
    public string Execute()
    {
        return _doorLock.Lock();
    }

    /// <summary>
    /// Undoes the command by unlocking the door.
    /// </summary>
    public string Undo()
    {
        return _doorLock.Unlock();
    }
}