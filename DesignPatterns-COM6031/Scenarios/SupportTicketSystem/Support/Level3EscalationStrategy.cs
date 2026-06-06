using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level3EscalationStrategy : IEscalationStrategy
{
    // This is the final level so always handle tickets.
    public bool CanHandle(Ticket.Ticket ticket) => true;
}