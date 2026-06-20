using System.Text;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;

/// <summary>
/// Represents a support ticket that can be passed through the support handler chain.
/// </summary>
public class Ticket
{
    public Ticket(Guid id, string title, string description, DateTime createdDate, TicketPriority priority,
        TicketCategory category)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        Priority = priority;
        Category = category;
    }

    /// <summary>
    /// Gets the unique ticket identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the ticket title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the ticket description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the date the ticket was created.
    /// </summary>
    public DateTime CreatedDate { get; }

    /// <summary>
    /// Gets the ticket priority.
    /// </summary>
    public TicketPriority Priority { get; }

    /// <summary>
    /// Gets the ticket category.
    /// </summary>
    public TicketCategory Category { get; }

    /// <summary>
    /// Returns the ticket details as formatted text.
    /// </summary>
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