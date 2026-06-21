using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

/// <summary>
/// Defines a support handler that can process a ticket or pass it to the next handler.
/// </summary>
public interface ISupportHandler
{
    /// <summary>
    /// Attempts to handle the supplied ticket.
    /// </summary>
    string Handle(Ticket ticket);
    
    /// <summary>
    /// Sets the next handler in the support chain.
    /// </summary>
    void SetNext(ISupportHandler handler);
}