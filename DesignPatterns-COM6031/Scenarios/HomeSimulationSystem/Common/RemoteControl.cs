namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

/// <summary>
/// Acts as the command invoker for the smart home simulation.
/// </summary>
public class RemoteControl
{
    private ICommand? _currentCommand;

    /// <summary>
    /// Executes the supplied command and stores it so it can be undone.
    /// </summary>
    public string PressButton(ICommand command)
    {
        _currentCommand = command;
        return command.Execute();
    }

    /// <summary>
    /// Undoes the most recently executed command.
    /// </summary>
    public string PressUndo()
    {
        if (_currentCommand == null)
        {
            return "Nothing to undo";
        }
        return _currentCommand.Undo();
    }
}