using Budget_Assistant.Models;

namespace Budget_Assistant.Services;

public class UserService
{
    private readonly List<UserAccount> _users = new();

    public UserAccount Login(string username)
    {
        // Try to find an existing user.
        UserAccount? user = _users.FirstOrDefault(u => u.Username == username);

        // If no user exists, create one.
        if (user == null)
        {
            user = new UserAccount
            {
                Username = username
            };

            _users.Add(user);

            Console.WriteLine($"Created new account for {username}.");
        }
        else
        {
            Console.WriteLine($"Welcome back, {username}!");
        }

        return user;
    }
}