using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that activates the smart home evening mode through the facade.
/// </summary>
public class EveningModeCommand : ICommand
{
    private readonly SmartHomeFacade _smartHomeFacade;
    private SmartHomeState? _previousState;

    public EveningModeCommand(SmartHomeFacade smartHomeFacade)
    {
        _smartHomeFacade = smartHomeFacade;
    }
    
    /// <summary>
    /// Captures the current smart home state, then activates evening mode.
    /// </summary>
    public string Execute()
    {
        // Cache the current state for undo.
        _previousState = _smartHomeFacade.GetCurrentState();
        
        // Now perform the evening mode settings.
        return _smartHomeFacade.EveningMode();
    }

    /// <summary>
    /// Restores the smart home state that existed before evening mode was activated.
    /// </summary>
    public string Undo()
    {
        return _previousState == null ? "Nothing to undo." : _smartHomeFacade.RestoreState(_previousState);
    }
}