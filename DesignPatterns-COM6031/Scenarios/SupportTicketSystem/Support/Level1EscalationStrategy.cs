using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Ticket;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;

public class Level1EscalationStrategy : IEscalationStrategy
{
    public bool CanHandle(Ticket.Ticket ticket)
    {
        return ticket.Category == TicketCategory.PasswordReset
            || ticket.Priority == TicketPriority.Low;
    }
}