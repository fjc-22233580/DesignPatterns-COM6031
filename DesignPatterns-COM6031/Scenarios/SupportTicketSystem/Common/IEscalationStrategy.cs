namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

/// <summary>
/// Defines a strategy for deciding whether a support handler can process a ticket.
/// </summary>
public interface IEscalationStrategy
{
    /// <summary>
    /// Determines whether the supplied ticket can be handled by the current support level.
    /// </summary>
    bool CanHandle(Models.Ticket ticket);
}