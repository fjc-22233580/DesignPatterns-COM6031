using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class DoorLockCommand : ICommand
{
    private readonly DoorLock _doorLock;

    public DoorLockCommand(DoorLock doorLock)
    {
        _doorLock = doorLock;
    }
    
    public string Execute()
    {
        return _doorLock.Lock();
    }

    public string Undo()
    {
        return _doorLock.Unlock();
    }
}