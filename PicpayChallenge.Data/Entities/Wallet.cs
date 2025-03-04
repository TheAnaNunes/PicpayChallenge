namespace PicpayChallenge.Data.Entities;

public class Wallet
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public double Balance { get; set; } = 0;
    public User User { get; set; }
    
    public Wallet() { }
}
