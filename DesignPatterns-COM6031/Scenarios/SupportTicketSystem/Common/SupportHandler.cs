namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Common;

public abstract class SupportHandler : ISupportHandler
{
    private ISupportHandler? _nextHandler;
    private readonly IEscalationStrategy _escalationStrategy;

    protected SupportHandler(IEscalationStrategy escalationStrategy)
    {
        _escalationStrategy = escalationStrategy;
    }

    public string Handle(Ticket.Ticket ticket)
    {
        // If we can handle this ticket, then solve.
        if (_escalationStrategy.CanHandle(ticket))
        {
            return Resolve(ticket);
        }

        // Could not resolve ticket this level, so pass onto next level
        var msg = $"Ticket: {ticket.Title} escalated to next level via {this.GetType().Name}";
        if (_nextHandler != null)
        {
            var nextHandler = _nextHandler.Handle(ticket);
            msg += $"{Environment.NewLine}{nextHandler}";
        }
        return msg;
    }
    
    protected abstract string Resolve(Ticket.Ticket ticket);
    
    public void SetNext(ISupportHandler handler)
    {
        _nextHandler = handler;
    }
}