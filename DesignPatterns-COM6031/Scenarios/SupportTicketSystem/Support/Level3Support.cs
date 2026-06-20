using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

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
    protected override string Resolve(Models.Ticket ticket)
    {
        return $"Level 3 resolved ticket {ticket.Title}";
    }
}