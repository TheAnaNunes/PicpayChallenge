
namespace PicpayChallenge.Middleware.Response;

public record ErroResponse(string Message)
{
    public static ErroResponse Fail(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException($"'{nameof(message)}' cannot be null or empty.", nameof(message));
        }

        return new(message);
    }
}
