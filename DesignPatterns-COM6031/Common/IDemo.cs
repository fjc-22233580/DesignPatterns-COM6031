namespace DesignPatterns_COM6031.Common;

/// <summary>
/// Defines a runnable console demonstration for the design pattern scenario.
/// </summary>
public interface IDemo
{
    /// <summary>
    /// Gets the display name used when showing the demonstration in the menu.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Runs the demonstration.
    /// </summary>
    void Run();
}