using Budget_Assistant.Core;
using Budget_Assistant.Models;
using Budget_Assistant.Services;

Console.WriteLine("=================================");
Console.WriteLine("Kodehode Budget Assistant");
Console.WriteLine("=================================");

Console.Write("Enter username: ");

string username = Console.ReadLine() ?? "";

UserService userService = new();
TransactionService transactionService = new();

UserAccount currentUser = userService.Login(username);

Menu menu = new();

bool running = true;

while (running)
{
    menu.Show();

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            transactionService.AddIncome(currentUser);
            break;

        case "2":
            transactionService.AddExpense(currentUser);
            break;

        case "3":
            transactionService.ShowTransactions(currentUser);
            break;

        case "4":
            transactionService.ShowSummary(currentUser);
            break;

        case "5":
            transactionService.FilterTransactions(currentUser);
            break;

        case "6":
            transactionService.Save(currentUser);
            break;

        case "7":
            Console.WriteLine("Goodbye!");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}