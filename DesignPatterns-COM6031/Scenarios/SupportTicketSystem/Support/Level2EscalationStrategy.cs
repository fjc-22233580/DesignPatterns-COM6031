using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Escalation strategy that allows Level 2 support to handle user setup, software, or medium-priority tickets.
/// </summary>
public class Level2EscalationStrategy : IEscalationStrategy
{
    /// <summary>
    /// Determines whether the ticket can be handled by Level 2 support.
    /// </summary>
    public bool CanHandle(Ticket ticket)
    {
        return ticket.Category == TicketCategory.SoftwareIssue
               || ticket.Category == TicketCategory.NewUser
               || ticket.Priority == TicketPriority.Medium;
    }
}