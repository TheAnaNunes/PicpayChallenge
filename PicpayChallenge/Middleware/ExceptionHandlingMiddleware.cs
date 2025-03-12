using PicpayChallenge.Services.Exceptions.TransactionException;
using PicpayChallenge.Services.Exceptions.UserCreationException;
using PicpayChallenge.Middleware.Response; 

namespace PicpayChallenge.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex switch
        {
            InvalidDocumentException => StatusCodes.Status400BadRequest,
            FailedAuthenticationException => StatusCodes.Status419AuthenticationTimeout,
            FailedNotificationException => StatusCodes.Status408RequestTimeout,
            InvalidSenderException => StatusCodes.Status400BadRequest,
            InvalidUserException => StatusCodes.Status400BadRequest,
            NoBalanceException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = ErroResponse.Fail(ex.Message);

        return context.Response.WriteAsJsonAsync(response);
    }
}
