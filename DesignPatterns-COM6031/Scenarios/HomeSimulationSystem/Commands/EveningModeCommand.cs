using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

public class EveningModeCommand : ICommand
{
    private readonly SmartHomeFacade _smartHomeFacade;
    private SmartHomeState? _previousState;

    public EveningModeCommand(SmartHomeFacade smartHomeFacade)
    {
        _smartHomeFacade = smartHomeFacade;
    }
    
    public string Execute()
    {
        // Cache the current state for undo 
        _previousState = _smartHomeFacade.GetCurrentState();
        
        // Now perform the evening mode settings.
        return _smartHomeFacade.EveningMode();
    }

    public string Undo()
    {
        return _previousState == null ? "Nothing to undo." : _smartHomeFacade.RestoreState(_previousState);
    }
}