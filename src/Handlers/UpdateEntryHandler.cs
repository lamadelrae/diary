using DiaryApp.Data;

namespace DiaryApp.Handlers;

public static class UpdateEntryHandler
{
    public static void Execute(int id, string? newTitle = null, string? newContent = null)
    {
        using var context = new DiaryContext();
        
        var entry = context.DiaryEntries.Find(id);
        
        if (entry == null)
        {
            Console.WriteLine($"✗ No diary entry found with ID: {id}");
            return;
        }

        bool hasChanges = false;
        
        if (!string.IsNullOrWhiteSpace(newTitle))
        {
            entry.Title = newTitle;
            hasChanges = true;
        }
        
        if (!string.IsNullOrWhiteSpace(newContent))
        {
            entry.Content = newContent;
            hasChanges = true;
        }

        if (hasChanges)
        {
            entry.UpdatedAt = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine($"✓ Diary entry #{id} updated successfully");
        }
        else
        {
            Console.WriteLine("No changes provided for the entry");
        }
    }
}