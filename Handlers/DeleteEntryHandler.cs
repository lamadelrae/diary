using DiaryApp.Data;

namespace DiaryApp.Handlers;

public static class DeleteEntryHandler
{
    public static void Execute(int id)
    {
        using var context = new DiaryContext();
        
        var entry = context.DiaryEntries.Find(id);
        
        if (entry == null)
        {
            Console.WriteLine($"✗ No diary entry found with ID: {id}");
            return;
        }

        Console.WriteLine($"Are you sure you want to delete '{entry.Title}'? (y/N)");
        var confirmation = Console.ReadLine()?.ToLower();
        
        if (confirmation == "y" || confirmation == "yes")
        {
            context.DiaryEntries.Remove(entry);
            context.SaveChanges();
            Console.WriteLine($"✓ Diary entry #{id} deleted successfully");
        }
        else
        {
            Console.WriteLine("Delete operation cancelled");
        }
    }
}