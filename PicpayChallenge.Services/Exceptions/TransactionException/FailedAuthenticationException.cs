
namespace PicpayChallenge.Services.Exceptions.TransactionException;

public class FailedAuthenticationException : PicpayException
{
    private const string _defaultMessage = "Failed Authentication! Please try again";
    public FailedAuthenticationException()
        :base(_defaultMessage) { }
    public FailedAuthenticationException(string? message) 
        : base(message) { }

    public FailedAuthenticationException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
