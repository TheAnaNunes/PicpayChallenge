
namespace PicpayChallenge.Services.Exceptions.TransactionException;

public class FailedNotificationException : PicpayException
{
    private const string _defaultMessage = "Failed send notification. Please try again";
    public FailedNotificationException()
        : base(_defaultMessage) { }
    public FailedNotificationException(string? message) 
        : base(message) { }

    public FailedNotificationException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
