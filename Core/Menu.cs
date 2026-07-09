namespace Budget_Assistant.Core;

public class Menu
{
    // Displays the application's main menu.
    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("========== Main Menu ==========");
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Show Transactions");
        Console.WriteLine("4. Show Summary");
        Console.WriteLine("5. Filter Transactions");
        Console.WriteLine("6. Edit Transaction");
        Console.WriteLine("7. Delete Transaction");
        Console.WriteLine("8. Exit");
        Console.WriteLine("===============================");

        Console.Write("Choose an option: ");
    }
}