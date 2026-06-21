using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that unlocks the door.
/// </summary>
public class UnlockDoorCommand : ICommand
{
    private readonly DoorLock _doorLock;

    public UnlockDoorCommand(DoorLock doorLock)
    {
        _doorLock = doorLock;
    }
    
    /// <summary>
    /// Executes the unlock action on the door lock receiver.
    /// </summary>
    public string Execute()
    {
        return _doorLock.Unlock();
    }

    /// <summary>
    /// Undoes the command by locking the door again.
    /// </summary>
    public string Undo()
    {
        return _doorLock.Lock();
    }
}