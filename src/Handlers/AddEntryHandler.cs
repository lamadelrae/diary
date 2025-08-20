using DiaryApp.Data;
using DiaryApp.Models;

namespace DiaryApp.Handlers;

public static class AddEntryHandler
{
    public static void Execute(string title, string content)
    {
        using var context = new DiaryContext();
        
        var entry = new DiaryEntry
        {
            Title = title,
            Content = content,
            CreatedAt = DateTime.Now
        };

        context.DiaryEntries.Add(entry);
        context.SaveChanges();
        
        Console.WriteLine($"✓ Diary entry '{title}' added successfully with ID: {entry.Id}");
    }
}