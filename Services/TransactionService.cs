using Budget_Assistant.Models;

namespace Budget_Assistant.Services;

public class TransactionService
{
    public void AddIncome(UserAccount user)
    {
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? "";

        Transaction transaction = new()
        {
            Id = user.Transactions.Count + 1,
            Description = description,
            Amount = amount,
            Category = category,
            Date = DateTime.Now,
            Type = TransactionType.Income
        };

        user.Transactions.Add(transaction);

        Console.WriteLine();
        Console.WriteLine("Income added successfully!");
    }

    public void AddExpense(UserAccount user)
    {
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? "";

        Transaction transaction = new()
        {
            Id = user.Transactions.Count + 1,
            Description = description,
            Amount = amount,
            Category = category,
            Date = DateTime.Now,
            Type = TransactionType.Expense
        };

        user.Transactions.Add(transaction);

        Console.WriteLine();
        Console.WriteLine("Expense added successfully!");
    }

    public void ShowTransactions(UserAccount user)
    {
        Console.WriteLine();

        if (user.Transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        Console.WriteLine("===== Transactions =====");

        foreach (Transaction transaction in user.Transactions)
        {
            Console.WriteLine($"ID:          {transaction.Id}");
            Console.WriteLine($"Type:        {transaction.Type}");
            Console.WriteLine($"Description: {transaction.Description}");
            Console.WriteLine($"Amount:      {transaction.Amount:C}");
            Console.WriteLine($"Category:    {transaction.Category}");
            Console.WriteLine($"Date:        {transaction.Date:g}");
            Console.WriteLine("--------------------------------------");
        }
    }
    

    public void ShowSummary(UserAccount user)
    {
        decimal totalIncome = user.Transactions
            .Where(t => t.Type == TransactionType.Income)
            .Sum(t => t.Amount);

        decimal totalExpenses = user.Transactions
            .Where(t => t.Type == TransactionType.Expense)
            .Sum(t => t.Amount);

        int expenseCount = user.Transactions
            .Count(t => t.Type == TransactionType.Expense);

        decimal balance = totalIncome - totalExpenses;

        Console.WriteLine();

        Console.WriteLine("===== Account Summary =====");
        Console.WriteLine($"Total Income     : {totalIncome:C}");
        Console.WriteLine($"Expense Entries  : {expenseCount}");
        Console.WriteLine($"Total Expenses   : {totalExpenses:C}");
        Console.WriteLine($"Current Balance  : {balance:C}");
    }

    public void FilterTransactions(UserAccount user)
    {
        Console.WriteLine("Filtering will be implemented later.");
    }

    public void Save(UserAccount user)
    {
        Console.WriteLine("Saving will be implemented later.");
    }
}