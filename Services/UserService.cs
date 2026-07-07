using Budget_Assistant.Models;

namespace Budget_Assistant.Services;

public class UserService
{
    private readonly DataService _dataService = new();

    public UserAccount Login(string username)
    {
        // Try loading the user from disk.
        UserAccount? user = _dataService.Load(username);

        if (user != null)
        {
            Console.WriteLine($"Welcome back, {username}!");
            return user;
        }

        // No file found, create a new account.
        user = new UserAccount
        {
            Username = username
        };

        Console.WriteLine($"Created new account for {username}.");

        return user;
    }
}