using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level2Support : SupportHandler
{
    public Level2Support(IEscalationStrategy escalationStrategy) 
        : base(escalationStrategy)
    {
    }
        
    protected override string Resolve(Ticket.Ticket ticket)
    {
        return $"Level 2 resolved ticket {ticket.Title}";
    }
}