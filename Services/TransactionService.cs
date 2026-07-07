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
            PrintTransaction(transaction);
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
        Console.WriteLine();
        Console.WriteLine("===== Filter Transactions =====");
        Console.WriteLine("1. Last 24 hours");
        Console.WriteLine("2. Last week");
        Console.WriteLine("3. Last month");
        Console.WriteLine("4. Show all");

        Console.Write("Choice: ");

        string? choice = Console.ReadLine();

        IEnumerable<Transaction> filtered = user.Transactions;

        switch (choice)
        {
            case "1":
                filtered = user.Transactions
                    .Where(t => t.Date >= DateTime.Now.AddDays(-1));
                break;

            case "2":
                filtered = user.Transactions
                    .Where(t => t.Date >= DateTime.Now.AddDays(-7));
                break;

            case "3":
                filtered = user.Transactions
                    .Where(t => t.Date >= DateTime.Now.AddMonths(-1));
                break;

            case "4":
                break;

            default:
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine();

            if (!filtered.Any())
            {
                Console.WriteLine("No matching transactions.");
                return;
            }

        foreach (Transaction transaction in filtered)
        {
            PrintTransaction(transaction);
        }
    }
    
    public void Save(UserAccount user)
    {
        DataService dataService = new();

        dataService.Save(user);
    }

    // Prints one transaction in a readable format.
    private void PrintTransaction(Transaction transaction)
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