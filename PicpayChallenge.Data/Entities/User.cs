using System.Text.Json.Serialization;

namespace PicpayChallenge.Data.Entities;

public class User
{
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("document")]
    public string Document { get; set; }
    public Wallet Wallet { get; set; } = new();

    public User(string name, string email, string document)
    {
        Name = name;
        Email = email;
        Document = document;
    }
    public User() { }
}
