using DiaryApp.Data;
using DiaryApp.Handlers;
using DiaryApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp;

class Program
{
    static void Main(string[] args)
    {
        // Initialize database
        InitializeDatabase();
        
        ConsoleHelper.ShowWelcome();
        
        bool running = true;
        
        while (running)
        {
            try
            {
                ConsoleHelper.ShowMenu();
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddNewEntry();
                        break;
                    case "2":
                        ViewAllEntries();
                        break;
                    case "3":
                        ViewSpecificEntry();
                        break;
                    case "4":
                        UpdateEntry();
                        break;
                    case "5":
                        DeleteEntry();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using Personal Diary! Goodbye! 👋");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select 1-6.");
                        break;
                }
                
                if (running && choice != "6")
                {
                    ConsoleHelper.PressAnyKeyToContinue();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                ConsoleHelper.PressAnyKeyToContinue();
            }
        }
    }

    static void InitializeDatabase()
    {
        try
        {
            using var context = new DiaryContext();
            context.Database.EnsureCreated();
            Console.WriteLine("Database initialized successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to initialize database: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void AddNewEntry()
    {
        Console.WriteLine("\n--- Add New Diary Entry ---");
        
        var title = ConsoleHelper.GetInput("Enter title: ");
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        var content = ConsoleHelper.GetMultilineInput("Enter content:");
        if (string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("Content cannot be empty.");
            return;
        }

        AddEntryHandler.Execute(title, content);
    }

    static void ViewAllEntries()
    {
        FetchAllEntriesHandler.Execute();
    }

    static void ViewSpecificEntry()
    {
        Console.WriteLine("\n--- View Specific Entry ---");
        var id = ConsoleHelper.GetIntInput("Enter entry ID: ");
        FetchEntryByIdHandler.Execute(id);
    }

    static void UpdateEntry()
    {
        Console.WriteLine("\n--- Update Entry ---");
        var id = ConsoleHelper.GetIntInput("Enter entry ID to update: ");
        
        // First show the current entry
        var entry = FetchEntryByIdHandler.Execute(id);
        if (entry == null)
            return;

        Console.WriteLine("\nLeave empty to keep current value:");
        
        var newTitle = ConsoleHelper.GetInput($"New title (current: {entry.Title}): ");
        var newContent = ConsoleHelper.GetMultilineInput($"New content (current preview: {(entry.Content.Length > 50 ? entry.Content.Substring(0, 50) + "..." : entry.Content)}):");

        UpdateEntryHandler.Execute(id, 
            string.IsNullOrWhiteSpace(newTitle) ? null : newTitle,
            string.IsNullOrWhiteSpace(newContent) ? null : newContent);
    }

    static void DeleteEntry()
    {
        Console.WriteLine("\n--- Delete Entry ---");
        var id = ConsoleHelper.GetIntInput("Enter entry ID to delete: ");
        
        // First show the entry to be deleted
        var entry = FetchEntryByIdHandler.Execute(id);
        if (entry == null)
            return;

        DeleteEntryHandler.Execute(id);
    }
}
