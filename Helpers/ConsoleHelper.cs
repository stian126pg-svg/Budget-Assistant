namespace Budget_Assistant.Helpers;

public static class ConsoleHelper
{
    // Displays a page header.
    public static void Header(string title)
    {
        Console.Clear();

        Console.WriteLine("==========================================================");
        Console.WriteLine($" {title}");
        Console.WriteLine("==========================================================");
        Console.WriteLine();
    }

    // Draws a separator line.
    public static void Separator()
    {
        Console.WriteLine("----------------------------------------------------------");
    }

    // Displays a success message.
    public static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✔ {message}");
        Console.ResetColor();
    }

    // Displays an error message.
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✖ {message}");
        Console.ResetColor();
    }

    // Displays a warning message.
    public static void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠ {message}");
        Console.ResetColor();
    }

    // Displays the transaction table header.
    public static void TransactionTableHeader()
    {
        Console.WriteLine(" ID | Type     | Amount      | Category       | Date");
        Separator();
    }

    // Waits for the user before continuing.
    public static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();

        Console.Clear();
    }
}