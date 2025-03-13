using PicpayChallenge.Services.Exceptions.TransactionException;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class AuthenticationService(HttpClient httpClient) : IAuthenticationService
{
    private const string _endpoint = "https://util.devi.tools/api/v2/authorize";
    public async Task<HttpResponseMessage?> GetAuthUserAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            try
            {
                var response = await httpClient.GetAsync(_endpoint);

                if (response.IsSuccessStatusCode)
                    return response;
                    
                throw new FailedAuthenticationException();
            }
            catch (FailedAuthenticationException)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                continue;
            }
        }
        return null;
    }
}
