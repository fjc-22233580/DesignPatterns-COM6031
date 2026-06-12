using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class UnlockDoorCommand : ICommand
{
    private readonly DoorLock _doorLock;

    public UnlockDoorCommand(DoorLock doorLock)
    {
        _doorLock = doorLock;
    }
    
    public string Execute()
    {
        return _doorLock.Unlock();
    }

    public string Undo()
    {
        return _doorLock.Lock();
    }
}