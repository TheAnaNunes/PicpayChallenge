namespace PicpayChallenge.Services.Exceptions.UserCreationException;

public class InvalidDocumentException : PicpayException
{
    private const string _defaultMessage = "Invalid Document! The Document need to be 11 or 14 characters";

    public InvalidDocumentException() 
        : base(_defaultMessage) { }
    public InvalidDocumentException(string? message) 
        : base(message ?? _defaultMessage) { }
    public InvalidDocumentException(string? message, Exception? innerException) 
        : base(message ?? _defaultMessage, innerException) { }
}
