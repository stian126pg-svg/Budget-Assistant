using Budget_Assistant.Services;
using Budget_Assistant.Models;

Console.WriteLine("=================================");
Console.WriteLine(" Kodehode Budget Assistant");
Console.WriteLine("=================================");

Console.Write("Enter username: ");

string username = Console.ReadLine() ?? "";

UserService userService = new();

UserAccount currentUser = userService.Login(username);

Console.WriteLine();
Console.WriteLine($"Current user: {currentUser.Username}");