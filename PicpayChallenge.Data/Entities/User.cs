namespace PicpayChallenge.Data.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Document { get; set; }
    public Wallet Wallet { get; set; } = new();

    public User(string name, string email, int document)
    {
        Name = name;
        Email = email;
        Document = document;
    }
    public User() { }
}
