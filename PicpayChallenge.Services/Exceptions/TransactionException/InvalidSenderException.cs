
namespace PicpayChallenge.Services.Exceptions.TransactionException;

public class InvalidSenderException : PicpayException
{
    private const string _defaultMessage = "Invalid Sender, Shopkeepers users can't made transactions";
    
    public InvalidSenderException()
        : base(_defaultMessage) { }
    public InvalidSenderException(string? message) 
        : base(message) { }

    public InvalidSenderException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
