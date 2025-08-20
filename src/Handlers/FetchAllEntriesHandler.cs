using DiaryApp.Data;

namespace DiaryApp.Handlers;

public static class FetchAllEntriesHandler
{
    public static void Execute()
    {
        using var context = new DiaryContext();
        
        var entries = context.DiaryEntries
            .OrderByDescending(e => e.CreatedAt)
            .ToList();
            
        if (!entries.Any())
        {
            Console.WriteLine("No diary entries found. Start by adding your first entry!");
            return;
        }

        Console.WriteLine($"\n--- All Diary Entries ({entries.Count}) ---");
        
        foreach (var entry in entries)
        {
            Console.WriteLine($"\n[{entry.Id}] {entry.Title}");
            Console.WriteLine($"    Created: {entry.CreatedAt:yyyy-MM-dd HH:mm:ss}");
            if (entry.UpdatedAt.HasValue)
            {
                Console.WriteLine($"    Updated: {entry.UpdatedAt:yyyy-MM-dd HH:mm:ss}");
            }
            
            // Show first 100 characters of content
            var preview = entry.Content.Length > 100 
                ? entry.Content.Substring(0, 100) + "..." 
                : entry.Content;
            Console.WriteLine($"    Preview: {preview}");
        }
        Console.WriteLine("─────────────────────────────────");
    }
}