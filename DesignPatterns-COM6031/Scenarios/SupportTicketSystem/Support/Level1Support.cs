using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level1Support : SupportHandler
{
    public Level1Support(IEscalationStrategy escalationStrategy) 
        : base(escalationStrategy)
    {
    }

    protected override string Resolve(Ticket.Ticket ticket)
    {
        return $"Level 1 resolved ticket {ticket.Title}";
    }
}