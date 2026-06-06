namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

public interface IEscalationStrategy
{
    bool CanHandle(Ticket.Ticket ticket);
}