using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Escalation strategy that allows Level 3 support to handle any remaining ticket.
/// </summary>
public class Level3EscalationStrategy : IEscalationStrategy
{
    /// <summary>
    /// Always accepts the ticket because Level 3 is the final support level.
    /// </summary>
    public bool CanHandle(Ticket ticket) => true;
}