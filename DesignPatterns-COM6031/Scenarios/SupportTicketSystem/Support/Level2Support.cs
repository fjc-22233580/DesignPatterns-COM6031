using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

/// <summary>
/// Concrete support handler for resolving Level 2 support tickets.
/// </summary>
public class Level2Support : SupportHandler
{
    public Level2Support(IEscalationStrategy escalationStrategy) 
        : base(escalationStrategy)
    {
    }
        
    /// <summary>
    /// Resolves a ticket that has been accepted by the Level 2 escalation strategy.
    /// </summary>
    protected override string Resolve(Models.Ticket ticket)
    {
        return $"{GetType().Name} resolved ticket with ID: {ticket.Id}";
    }
}