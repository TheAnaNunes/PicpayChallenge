
namespace PicpayChallenge.Middleware.Response;

public record ErroResponse(string Message, int? StatusCode)
{
    public static ErroResponse Fail(string message, int? statusCode)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException($"'{nameof(message)}' cannot be null or empty.", nameof(message));
        }

        if (statusCode is null)
        {
            throw new ArgumentNullException(nameof(statusCode));
        }

        return new(message, statusCode);
    }
}
