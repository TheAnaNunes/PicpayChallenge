namespace PicpayChallenge.Services.Services.Interface;

public interface IAuthenticationService
{
    Task<HttpResponseMessage?> GetAuthUserAsync();
}
