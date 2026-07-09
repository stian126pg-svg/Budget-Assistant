using Budget_Assistant.Models;

namespace Budget_Assistant.Services;

public class TransactionService
{
    // Handles saving user data.
    private readonly DataService _dataService = new();

    // Adds a new income transaction.
    public void AddIncome(UserAccount user)
    {
        CreateTransaction(user, TransactionType.Income);
    }

    // Adds a new expense transaction.
    public void AddExpense(UserAccount user)
    {
        CreateTransaction(user, TransactionType.Expense);
    }

    // Shows every transaction.
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

    // Shows an overview of the user's finances.
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

    // Filters transactions by date.
    public void FilterTransactions(UserAccount user)
    {
        Console.WriteLine();
        Console.WriteLine("===== Filter Transactions =====");
        Console.WriteLine("1. Last 24 Hours");
        Console.WriteLine("2. Last Week");
        Console.WriteLine("3. Last Month");
        Console.WriteLine("4. Show All");

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
                Console.WriteLine("Invalid choice.");
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

    // Saves the current user's data.
    public void Save(UserAccount user)
    {
        _dataService.Save(user);
    }

    // Allows editing of transactions younger than 24 hours.
    public void EditTransaction(UserAccount user)
    {
        Console.WriteLine();

        if (user.Transactions.Count == 0)
        {
            Console.WriteLine("No transactions available.");
            return;
        }

        ShowTransactions(user);

        Console.WriteLine();
        Console.Write("Enter transaction ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Transaction? transaction = FindTransaction(user, id);

        if (transaction == null)
        {
            Console.WriteLine("Transaction not found.");
            return;
        }

        if (!CanModify(transaction))
        {
            Console.WriteLine("Transaction is older than 24 hours.");
            return;
        }

        Console.Write("New Description: ");
        transaction.Description = Console.ReadLine() ?? transaction.Description;

        Console.Write("New Amount: ");

        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            transaction.Amount = amount;
        }

        Console.Write("New Category: ");
        transaction.Category = Console.ReadLine() ?? transaction.Category;

        _dataService.Save(user);

        Console.WriteLine();
        Console.WriteLine("Transaction updated successfully!");
    }

    // Deletes transactions younger than 24 hours.
    public void DeleteTransaction(UserAccount user)
    {
        Console.WriteLine();

        if (user.Transactions.Count == 0)
        {
            Console.WriteLine("No transactions available.");
            return;
        }

        ShowTransactions(user);

        Console.WriteLine();
        Console.Write("Enter transaction ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Transaction? transaction = FindTransaction(user, id);

        if (transaction == null)
        {
            Console.WriteLine("Transaction not found.");
            return;
        }

        if (!CanModify(transaction))
        {
            Console.WriteLine("Transaction is older than 24 hours.");
            return;
        }

        Console.Write("Are you sure? (Y/N): ");

        string? answer = Console.ReadLine();

        if (answer?.ToUpper() != "Y")
        {
            Console.WriteLine("Deletion cancelled.");
            return;
        }

        user.Transactions.Remove(transaction);

        _dataService.Save(user);

        Console.WriteLine();
        Console.WriteLine("Transaction deleted successfully!");
    }

    // -------------------------------------------------
    // Private Helper Methods
    // -------------------------------------------------

    // Creates either an income or expense transaction.
    private void CreateTransaction(UserAccount user, TransactionType type)
    {
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Amount: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? "";

        Transaction transaction = new()
        {
            Id = GetNextTransactionId(user),
            Description = description,
            Amount = amount,
            Category = category,
            Date = DateTime.Now,
            Type = type
        };

        user.Transactions.Add(transaction);

        _dataService.Save(user);

        Console.WriteLine();
        Console.WriteLine($"{type} added successfully!");
    }

    // Finds a transaction using its ID.
    private Transaction? FindTransaction(UserAccount user, int id)
    {
        return user.Transactions.FirstOrDefault(t => t.Id == id);
    }

    // Generates the next available ID.
    private int GetNextTransactionId(UserAccount user)
    {
        if (user.Transactions.Count == 0)
            return 1;

        return user.Transactions.Max(t => t.Id) + 1;
    }

    // Checks if the transaction can still be modified.
    private bool CanModify(Transaction transaction)
    {
        return transaction.Date >= DateTime.Now.AddHours(-24);
    }

    // Prints one transaction neatly.
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