namespace Budget_Assistant.Models;

public class Transaction
{
    public int Id { get; set; }

    public string Description { get; set; } = "";

    public decimal Amount { get; set; }

    public string Category { get; set; } = "";

    public DateTime Date { get; set; } = DateTime.Now;

    public TransactionType Type { get; set; }
}