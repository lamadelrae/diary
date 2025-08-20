namespace DiaryApp.Utils;

public static class ConsoleHelper
{
    public static void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║            Personal Diary            ║");
        Console.WriteLine("║         Command Line Interface       ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
    }

    public static void ShowMenu()
    {
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Add new entry");
        Console.WriteLine("2. View all entries");
        Console.WriteLine("3. View specific entry");
        Console.WriteLine("4. Update entry");
        Console.WriteLine("5. Delete entry");
        Console.WriteLine("6. Exit");
        Console.Write("\nSelect an option (1-6): ");
    }

    public static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetMultilineInput(string prompt)
    {
        Console.WriteLine(prompt);
        Console.WriteLine("(Press Enter twice to finish)");
        
        var lines = new List<string>();
        string? line;
        int emptyLineCount = 0;
        
        while ((line = Console.ReadLine()) != null)
        {
            if (string.IsNullOrEmpty(line))
            {
                emptyLineCount++;
                if (emptyLineCount >= 2)
                    break;
            }
            else
            {
                emptyLineCount = 0;
            }
            lines.Add(line);
        }
        
        // Remove trailing empty lines
        while (lines.Count > 0 && string.IsNullOrEmpty(lines[lines.Count - 1]))
        {
            lines.RemoveAt(lines.Count - 1);
        }
        
        return string.Join(Environment.NewLine, lines);
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            
            Console.WriteLine("Please enter a valid number.");
        }
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue...");
        try
        {
            Console.ReadKey();
        }
        catch (InvalidOperationException)
        {
            // Handle case when console input is redirected
            Console.ReadLine();
        }
    }
}