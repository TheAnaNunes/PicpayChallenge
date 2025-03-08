namespace PicpayChallenge.Services.Exceptions;

public class PicpayException : Exception
{
    public PicpayException(string? message) 
        : base(message) { }

    public PicpayException(string? message, Exception? innerException) 
        : base(message, innerException) { }
}
