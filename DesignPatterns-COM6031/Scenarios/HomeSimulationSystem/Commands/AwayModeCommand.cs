using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Commands;

/// <summary>
/// Command that activates the smart home away mode through the facade.
/// </summary>
public class AwayModeCommand : ICommand
{
    private readonly SmartHomeFacade _smartHomeFacade;
    private SmartHomeState? _previousState;
    
    public AwayModeCommand(SmartHomeFacade smartHomeFacade)
    {
        _smartHomeFacade = smartHomeFacade;
    }
    
    /// <summary>
    /// Captures the current smart home state, then activates away mode.
    /// </summary>
    public string Execute()
    {
        _previousState = _smartHomeFacade.GetCurrentState();

        return _smartHomeFacade.AwayMode();
    }

    /// <summary>
    /// Restores the smart home state that existed before away mode was activated.
    /// </summary>
    public string Undo()
    {
        return _previousState == null ? "Nothing to undo." : _smartHomeFacade.RestoreState(_previousState);
    }
}