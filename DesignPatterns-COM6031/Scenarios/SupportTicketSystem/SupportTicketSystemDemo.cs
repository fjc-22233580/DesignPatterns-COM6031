using System.Text;
using DesignPatterns_COM6031.Common;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Support;
using DesignPatterns_COM6031.Scenarios.SupportTicketSystem.Ticket;
using DesignPatterns_COM6031.Views;

namespace DesignPatterns_COM6031.Scenarios.SupportTicketSystem;

public class SupportTicketSystemDemo : IDemo
{
    private Level1Support _support;
    
    public string Name => "Supper ticket system demo";
    
    public void Run()
    {
        _support = new Level1Support(new Level1EscalationStrategy());
        var level2Support = new Level2Support(new Level2EscalationStrategy());
        var level3Support = new Level3Support(new Level3EscalationStrategy());
        
        _support.SetNext(level2Support);
        level2Support.SetNext(level3Support);
        
        var running = true;
        
        // Define the menu options for the main menu.
        var menuOptions = new List<MenuItem>
        {
            new MenuItem("Create L1 Ticket", CreateL1Ticket),
            new MenuItem("Create L2 Ticket", CreateL2Ticket),
            new MenuItem("Create L3 Ticket", CreateL3Ticket),
            new MenuItem("Return to previous menu", () => { running = false; }),
        };

        while (running)
        {
            int response = ConsoleView.PrintSelectableMenu(Name, menuOptions);
            menuOptions[response].Action();
        }
    }


    private void CreateL1Ticket()
    {
        var ticket = new Ticket.Ticket(
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
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
        ConsoleView.PrintMessage(Name, sb.ToString());
        
    }

    private void CreateL2Ticket()
    {
        var ticket = new Ticket.Ticket(
            Guid.Parse("22222222-2222-2222-2222-222222222222"),
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
        ConsoleView.PrintMessage(Name, sb.ToString());
    }
    
    private void CreateL3Ticket()
    {
        var ticket = new Ticket.Ticket(
            Guid.Parse("33333333-3333-3333-3333-333333333333"),
            "Production Server Outage",
            "The main production server is unavailable and all users are affected.",
            DateTime.Now,
            TicketPriority.High,
            TicketCategory.HardwareIssue);
        
        var sb = new StringBuilder();
        sb.AppendLine("L2 Ticket created:");
        sb.AppendLine();
        sb.AppendLine(ticket.ToString());
        sb.AppendLine(_support.Handle(ticket));
        ConsoleView.PrintMessage(Name, sb.ToString());
    }
}