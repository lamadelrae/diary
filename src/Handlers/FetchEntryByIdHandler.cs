using DiaryApp.Data;
using DiaryApp.Models;

namespace DiaryApp.Handlers;

public static class FetchEntryByIdHandler
{
    public static DiaryEntry? Execute(int id)
    {
        using var context = new DiaryContext();
        
        var entry = context.DiaryEntries.Find(id);
        
        if (entry == null)
        {
            Console.WriteLine($"✗ No diary entry found with ID: {id}");
            return null;
        }

        Console.WriteLine($"\n--- Diary Entry #{entry.Id} ---");
        Console.WriteLine($"Title: {entry.Title}");
        Console.WriteLine($"Created: {entry.CreatedAt:yyyy-MM-dd HH:mm:ss}");
        if (entry.UpdatedAt.HasValue)
        {
            Console.WriteLine($"Updated: {entry.UpdatedAt:yyyy-MM-dd HH:mm:ss}");
        }
        Console.WriteLine($"\nContent:\n{entry.Content}");
        Console.WriteLine("─────────────────────────────────");
        
        return entry;
    }
}