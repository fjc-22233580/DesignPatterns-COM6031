namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

/// <summary>
/// Defines the common interface for commands that can be executed and undone.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Executes the command action.
    /// </summary>
    string Execute();

    /// <summary>
    /// Reverses the command action where possible.
    /// </summary>
    string Undo();
}