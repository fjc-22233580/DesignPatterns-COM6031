using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level3Support : SupportHandler
{
    public Level3Support(IEscalationStrategy escalationStrategy) : base(escalationStrategy)
    {
    }
    
    protected override string Resolve(Ticket.Ticket ticket)
    {
        return $"Level 3 resolved ticket {ticket.Title}";
    }
}