using System.Text;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Ticket;

public class Ticket
{

    public Ticket(Guid id, string title, string description, DateTime createdDate, TicketPriority priority, TicketCategory category)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        Priority = priority;
        Category = category;
    }
    
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime CreatedDate { get; }
    public TicketPriority Priority { get; }
    public TicketCategory Category { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Description: {Description}");
        sb.AppendLine($"Created on: {CreatedDate.ToShortDateString()}");
        sb.AppendLine($"Priority: {Priority.ToString()}");
        sb.AppendLine($"Category: {Category.ToString()}");
        return sb.ToString();
    }
}