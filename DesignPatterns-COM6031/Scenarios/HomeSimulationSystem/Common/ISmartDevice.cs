namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

/// <summary>
/// Defines the common name property shared by smart home devices.
/// </summary>
public interface ISmartDevice
{
    /// <summary>
    /// Gets the display name of the smart device.
    /// </summary>
    string Name { get; }
}