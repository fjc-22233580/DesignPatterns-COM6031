using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

/// <summary>
/// Base support handler that either resolves a ticket or passes it to the next handler in the chain.
/// </summary>
public abstract class SupportHandler : ISupportHandler
{
    private ISupportHandler? _nextHandler;
    private readonly IEscalationStrategy _escalationStrategy;

    protected SupportHandler(IEscalationStrategy escalationStrategy)
    {
        _escalationStrategy = escalationStrategy;
    }

    /// <summary>
    /// Handles the ticket if the assigned escalation strategy allows it, otherwise passes it along the chain.
    /// </summary>
    public string Handle(Ticket ticket)
    {
        // If we can handle this ticket, then solve.
        if (_escalationStrategy.CanHandle(ticket))
        {
            return Resolve(ticket);
        }

        // Could not resolve ticket this level, so pass onto next level.
        var msg = $"Ticket: {ticket.Title} escalated to next level via {this.GetType().Name}";
        if (_nextHandler != null)
        {
            var nextHandler = _nextHandler.Handle(ticket);
            msg += $"{Environment.NewLine}{nextHandler}";
        }

        return msg;
    }

    /// <summary>
    /// Resolves the ticket using the behaviour specific to the concrete support level.
    /// </summary>
    protected abstract string Resolve(Ticket ticket);

    /// <summary>
    /// Sets the next handler in the support chain.
    /// </summary>
    public void SetNext(ISupportHandler handler)
    {
        _nextHandler = handler;
    }
}