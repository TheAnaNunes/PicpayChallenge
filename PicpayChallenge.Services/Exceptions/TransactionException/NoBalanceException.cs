
namespace PicpayChallenge.Services.Exceptions.TransactionException;

public class NoBalanceException : PicpayException
{
    private const string _defaultMessage = "No Balance Enough";
    public NoBalanceException()
        : base(_defaultMessage) { }
    public NoBalanceException(string? message) 
        : base(message) { }

    public NoBalanceException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
