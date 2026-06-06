using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Ticket;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level2EscalationStrategy : IEscalationStrategy
{
    public bool CanHandle(Ticket.Ticket ticket)
    {
        return ticket.Category == TicketCategory.SoftwareIssue
               || ticket.Category == TicketCategory.NewUser
               || ticket.Priority == TicketPriority.Medium;
    }
}