using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Concrete support handler for resolving Level 3 support tickets.
/// </summary>
public class Level3Support : SupportHandler
{
    public Level3Support(IEscalationStrategy escalationStrategy) : base(escalationStrategy)
    {
    }
    
    /// <summary>
    /// Resolves a ticket that has been escalated to Level 3 support.
    /// </summary>
    protected override string Resolve(Ticket ticket)
    {
        return $"{GetType().Name} resolved ticket with ID: {ticket.Id}";
    }
}