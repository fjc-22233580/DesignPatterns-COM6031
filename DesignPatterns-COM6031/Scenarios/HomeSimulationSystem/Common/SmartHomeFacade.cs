using System.Text;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

/// <summary>
/// Stores a snapshot of the smart home state so it can be restored later.
/// </summary>
public record SmartHomeState(bool IsLightOn, bool IsDoorLocked, int Temperature);

/// <summary>
/// Provides a simplified interface for controlling multiple smart home devices together.
/// </summary>
public class SmartHomeFacade
{
    private readonly Light _light;
    private readonly Thermostat _thermostat;
    private readonly DoorLock _doorLock;

    public SmartHomeFacade(Light light, Thermostat thermostat, DoorLock doorLock)
    {
        _light = light;
        _thermostat = thermostat;
        _doorLock = doorLock;
    }

    /// <summary>
    /// Gets or sets the target temperature used when activating evening mode.
    /// </summary>
    public int EveningTemperature { get; set; }

    /// <summary>
    /// Gets or sets the target temperature used when activating away mode.
    /// </summary>
    public int AwayTemperature { get; set; }
    
    /// <summary>
    /// Captures the current state of each smart home device.
    /// </summary>
    public SmartHomeState GetCurrentState()
    {
        return new SmartHomeState(
            _light.IsLightOn,
            _doorLock.IsLocked,
            _thermostat.Temperature);
    }

    /// <summary>
    /// Restores each smart home device to a previously captured state.
    /// </summary>
    public string RestoreState(SmartHomeState state)
    {
        _light.SetPower(state.IsLightOn);
        _doorLock.SetLocked(state.IsDoorLocked);
        _thermostat.SetTemperature(state.Temperature);

        return "Smart home restored to previous state.";
    }

    /// <summary>
    /// Activates evening mode by coordinating the light, thermostat, and door lock.
    /// </summary>
    public string EveningMode()
    {
        var lightResponse = _light.TurnOn();
        var thermostatResponse = _thermostat.SetTemperature(EveningTemperature);
        var doorResponse = _doorLock.Lock();

        // Assemble the individual device responses into one message for the caller.
        var sb = new StringBuilder();
        sb.AppendLine("Evening mode activated:");
        sb.AppendLine($"{lightResponse}");
        sb.AppendLine($"{thermostatResponse}");
        sb.AppendLine($"{doorResponse}");
        return sb.ToString();
    }

    /// <summary>
    /// Activates away mode by coordinating the light, thermostat, and door lock.
    /// </summary>
    public string AwayMode()
    {
        var lightResponse = _light.TurnOff();
        var thermostatResponse = _thermostat.SetTemperature(AwayTemperature);
        var doorResponse = _doorLock.Lock();
        
        // Assemble the individual device responses into one message for the caller.
        var sb = new StringBuilder();
        sb.AppendLine("Away mode activated:");
        sb.AppendLine($"{lightResponse}");
        sb.AppendLine($"{thermostatResponse}");
        sb.AppendLine($"{doorResponse}");
        return sb.ToString();
    }
}