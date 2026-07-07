using System.Text.Json;
using Budget_Assistant.Models;

namespace Budget_Assistant.Services;

public class DataService
{
    private const string DataFolder = "Data";

    // Saves one user's data to a JSON file.
    public void Save(UserAccount user)
    {
        // Create the Data folder if it doesn't already exist.
        Directory.CreateDirectory(DataFolder);

        string filePath = Path.Combine(DataFolder, $"{user.Username}.json");

        // Convert the user object into formatted JSON.
        string json = JsonSerializer.Serialize(user, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        // Write the JSON to disk.
        File.WriteAllText(filePath, json);

        Console.WriteLine("Data saved successfully!");
    }

    // Loads a user from disk, or returns null if no file exists.
    public UserAccount? Load(string username)
    {
        string filePath = Path.Combine(DataFolder, $"{username}.json");

        if (!File.Exists(filePath))
        {
            return null;
        }

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<UserAccount>(json);
    }
}