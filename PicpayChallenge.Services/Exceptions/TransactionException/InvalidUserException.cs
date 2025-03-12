
namespace PicpayChallenge.Services.Exceptions.TransactionException;

public class InvalidUserException : PicpayException
{
    private const string _defaultMessage = "Invalid User(s)!";

    public InvalidUserException()
        : base(_defaultMessage) { }
    public InvalidUserException(string? message) 
        : base(message) { }

    public InvalidUserException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
