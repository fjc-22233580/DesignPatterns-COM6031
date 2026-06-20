using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Escalation strategy that allows Level 1 support to handle simple or low-priority tickets.
/// </summary>
public class Level1EscalationStrategy : IEscalationStrategy
{
    /// <summary>
    /// Determines whether the ticket can be handled by Level 1 support.
    /// </summary>
    public bool CanHandle(Models.Ticket ticket)
    {
        return ticket.Category == TicketCategory.PasswordReset
               || ticket.Priority == TicketPriority.Low;
    }
}