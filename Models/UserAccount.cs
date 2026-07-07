namespace Budget_Assistant.Models;

public class UserAccount
{
    public string Username { get; set; } = "";

    public List<Transaction> Transactions { get; set; } = new();
}