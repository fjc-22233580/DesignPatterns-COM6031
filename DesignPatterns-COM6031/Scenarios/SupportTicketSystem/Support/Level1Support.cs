using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Concrete support handler for resolving Level 1 support tickets.
/// </summary>
public class Level1Support : SupportHandler
{
    public Level1Support(IEscalationStrategy escalationStrategy) 
        : base(escalationStrategy)
    {
    }

    /// <summary>
    /// Resolves a ticket that has been accepted by the Level 1 escalation strategy.
    /// </summary>
    protected override string Resolve(Ticket ticket)
    {
        return $"Level 1 resolved ticket {ticket.Title}";
    }
}