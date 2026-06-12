namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

public class RemoteControl
{
    private ICommand? _currentCommand;

    public string PressButton(ICommand command)
    {
        _currentCommand = command;
        return command.Execute();
    }

    public string PressUndo()
    {
        if (_currentCommand == null)
        {
            return "Nothing to undo";
        }
        return _currentCommand.Undo();
    }
}