namespace Budget_Assistant.Core;

public class Menu
{
    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("========== Main Menu ==========");
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Show Transactions");
        Console.WriteLine("4. Show Summary");
        Console.WriteLine("5. Filter Transactions");
        Console.WriteLine("6. Save");
        Console.WriteLine("7. Exit");
        Console.WriteLine("===============================");

        Console.Write("Choose an option: ");
    }
}