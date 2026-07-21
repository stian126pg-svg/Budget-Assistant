// ================================================================
// Description:
// Controls the appearance of the console application.
// Responsible for headers, menus, tables, colours,
// messages and reusable UI components.

namespace Budget_Assistant.UI;

public static class ConsoleUI
{
    // Width used throughout the application.
    private const int Width = 62;

    // Draws a full horizontal border.
    public static void DrawBorder()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('═', Width));
        Console.ResetColor();
    }

    // Prints centered text.
    public static void CenterText(string text)
    {
        int padding = (Width - text.Length) / 2;

        if (padding < 0)
            padding = 0;

        Console.WriteLine(new string(' ', padding) + text);
    }

    // Clears the console and prints the application banner.
    public static void SplashScreen()
    {
        Console.Clear();

        DrawBorder();

        Console.ForegroundColor = ConsoleColor.Cyan;
        CenterText("KODEHODE BUDGET ASSISTANT");
        Console.ResetColor();

        CenterText("Version 1.1.0");

        DrawBorder();

        Console.WriteLine();
    }

    // Displays a page header.
    public static void Header(string title)
    {
        Console.Clear();

        DrawBorder();

        Console.ForegroundColor = ConsoleColor.Cyan;
        CenterText(title);
        Console.ResetColor();

        DrawBorder();

        Console.WriteLine();
    }

    // Draws a separator.
    public static void Separator()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('─', Width));
        Console.ResetColor();
    }

    // Prints a success message.
    public static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✔ {message}");
        Console.ResetColor();
    }

    // Prints an error message.
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✖ {message}");
        Console.ResetColor();
    }

    // Prints a warning.
    public static void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠ {message}");
        Console.ResetColor();
    }

    // Prints a normal information message.
    public static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    // Prints the transaction table header.
    public static void TransactionTableHeader()
    {
        Separator();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(
            $"{"ID",-5}" +
            $"{"TYPE",-12}" +
            $"{"AMOUNT",-15}" +
            $"{"CATEGORY",-18}" +
            $"DATE");

        Console.ResetColor();

        Separator();
    }

    // Prints a footer.
    public static void Footer()
    {
        Console.WriteLine();
        DrawBorder();
    }

    // Waits before continuing.
    public static void Pause()
    {
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Press any key to continue...");
        Console.ResetColor();

        Console.ReadKey(true);
    }

    // Clears the console.
    public static void Clear()
    {
        Console.Clear();
    }

    // Prints the goodbye screen.
    public static void Goodbye()
    {
        Console.Clear();

        DrawBorder();

        Console.ForegroundColor = ConsoleColor.Green;

        CenterText("Thank you for using");
        CenterText("Budget Assistant!");

        Console.ResetColor();

        DrawBorder();
    }
}