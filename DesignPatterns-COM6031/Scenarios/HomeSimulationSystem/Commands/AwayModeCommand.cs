using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class AwayModeCommand : ICommand
{
    private readonly SmartHomeFacade _smartHomeFacade;
    private SmartHomeState? _previousState;
    
    public AwayModeCommand(SmartHomeFacade smartHomeFacade)
    {
        _smartHomeFacade = smartHomeFacade;
    }
    
    public string Execute()
    {
        _previousState = _smartHomeFacade.GetCurrentState();

        return _smartHomeFacade.AwayMode();
    }

    public string Undo()
    {
        return _previousState == null ? "Nothing to undo." : _smartHomeFacade.RestoreState(_previousState);
    }
}