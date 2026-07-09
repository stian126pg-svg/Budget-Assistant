namespace Budget_Assistant.Helpers;

public static class ConsoleHelper
{
    // Clears the console and prints a header.
    public static void Header(string title)
    {
        Console.Clear();

        Console.WriteLine("==============================");
        Console.WriteLine($" {title}");
        Console.WriteLine("==============================");
        Console.WriteLine();
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