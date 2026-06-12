using System.Text;
using DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Devices;

namespace DesignPatterns_COM6031.Scenarios.HomeSimulationSystem.Common;

public record SmartHomeState(bool IsLightOn, bool IsDoorLocked, int Temperature);

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

    public int EveningTemperature { get; set; }
    public int AwayTemperature { get; set; }
    
    public SmartHomeState GetCurrentState()
    {
        return new SmartHomeState(
            _light.IsLightOn,
            _doorLock.IsLocked,
            _thermostat.Temperature);
    }

    public string RestoreState(SmartHomeState state)
    {
        _light.SetPower(state.IsLightOn);
        _doorLock.SetLocked(state.IsDoorLocked);
        _thermostat.SetTemperature(state.Temperature);

        return "Smart home restored to previous state.";
    }

    public string EveningMode()
    {
        var lightResponse = _light.TurnOn();
        var thermostatResponse = _thermostat.SetTemperature(EveningTemperature);
        var doorResponse = _doorLock.Lock();

        // Assembled the response to report back up.
        var sb = new StringBuilder();
        sb.AppendLine("Evening mode activated:");
        sb.AppendLine($"{lightResponse}");
        sb.AppendLine($"{thermostatResponse}");
        sb.AppendLine($"{doorResponse}");
        return sb.ToString();
    }

    public string AwayMode()
    {
        var lightResponse = _light.TurnOff();
        var thermostatResponse = _thermostat.SetTemperature(AwayTemperature);
        var doorResponse = _doorLock.Lock();
        
        // Assembled the response to report back up.
        var sb = new StringBuilder();
        sb.AppendLine("Away mode activated:");
        sb.AppendLine($"{lightResponse}");
        sb.AppendLine($"{thermostatResponse}");
        sb.AppendLine($"{doorResponse}");
        return sb.ToString();
    }
}