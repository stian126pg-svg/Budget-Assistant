namespace Budget_Assistant.Helpers;

public static class InputHelper
{
    // Reads a decimal value safely.
    public static decimal ReadDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;

            Console.WriteLine("Invalid number. Try again.");
        }
    }

    // Reads an integer safely.
    public static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Invalid number. Try again.");
        }
    }

    // Reads text.
    public static string ReadString(string message)
    {
        Console.Write(message);

        return Console.ReadLine() ?? "";
    }
}