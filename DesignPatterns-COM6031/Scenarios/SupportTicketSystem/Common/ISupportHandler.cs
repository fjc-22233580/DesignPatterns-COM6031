namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

public interface ISupportHandler
{
    string Handle(Ticket.Ticket ticket);
    
    void SetNext(ISupportHandler handler);
}