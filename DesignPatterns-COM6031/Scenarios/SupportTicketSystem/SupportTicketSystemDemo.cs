using System.Text;
using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Models;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem;

/// <summary>
/// Demonstrates the support ticket scenario using Chain of Responsibility and Strategy patterns.
/// </summary>
public class SupportTicketSystemDemo : IDemo
{
    private Level1Support _support;
    
    /// <summary>
    /// Gets the display name used in the main application menu.
    /// </summary>
    public string Name => "Support ticket system demo";
    
    /// <summary>
    /// Runs the support ticket scenario menu.
    /// </summary>
    public void Run()
    {
        // Create each support level with its own escalation strategy.
        _support = new Level1Support(new Level1EscalationStrategy());
        var level2Support = new Level2Support(new Level2EscalationStrategy());
        var level3Support = new Level3Support(new Level3EscalationStrategy());
        
        // Link the handlers together to form the support escalation chain.
        _support.SetNext(level2Support);
        level2Support.SetNext(level3Support);
        
        var running = true;
        
        // Each menu option creates a ticket designed to be resolved at a different support level.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Create L1 Ticket", CreateL1Ticket),
            new MenuItem("Create L2 Ticket", CreateL2Ticket),
            new MenuItem("Create L3 Ticket", CreateL3Ticket),
            new MenuItem("Return to previous menu", () => { running = false; }),
        };

        while (running)
        {
            var response = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            response.Action();
        }
    }

    /// <summary>
    /// Creates a low-priority password reset ticket that should be handled by Level 1 support.
    /// </summary>
    private void CreateL1Ticket()
    {
        var ticket = new Ticket(
            "0001",
            "Unable to Login",
            "User has forgotten their password and cannot access the support portal.",
            DateTime.Now,
            TicketPriority.Low,
            TicketCategory.PasswordReset);

        var sb = new StringBuilder();
        sb.AppendLine("L1 Ticket created:");
        sb.AppendLine();
        sb.AppendLine(ticket.ToString());
        sb.AppendLine(_support.Handle(ticket));
        sb.AppendLine();
        ConsoleView.PrintMessage(Name, sb.ToString());
        
    }

    /// <summary>
    /// Creates a medium-priority software issue ticket that should escalate to Level 2 support.
    /// </summary>
    private void CreateL2Ticket()
    {
        var ticket = new Ticket(
            "0002",
            "Printer Offline",
            "The office network printer is not responding to print requests.",
            DateTime.Now,
            TicketPriority.Medium,
            TicketCategory.SoftwareIssue);
        
        var sb = new StringBuilder();
        sb.AppendLine("L2 Ticket created:");
        sb.AppendLine();
        sb.AppendLine(ticket.ToString());
        sb.AppendLine(_support.Handle(ticket));
        sb.AppendLine();
        ConsoleView.PrintMessage(Name, sb.ToString());
    }
    
    /// <summary>
    /// Creates a high-priority hardware issue ticket that should escalate to Level 3 support.
    /// </summary>
    private void CreateL3Ticket()
    {
        var ticket = new Ticket(
            "0003",
            "Production Server Outage",
            "The main production server is unavailable and all users are affected.",
            DateTime.Now,
            TicketPriority.High,
            TicketCategory.HardwareIssue);
        
        var sb = new StringBuilder();
        sb.AppendLine("L3 Ticket created:");
        sb.AppendLine();
        sb.AppendLine(ticket.ToString());
        sb.AppendLine(_support.Handle(ticket));
        sb.AppendLine();
        ConsoleView.PrintMessage(Name, sb.ToString());
    }
}