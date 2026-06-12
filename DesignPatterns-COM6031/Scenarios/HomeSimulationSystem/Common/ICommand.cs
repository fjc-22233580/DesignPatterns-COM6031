namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

public interface ICommand
{
    string Execute();
    string Undo();
}