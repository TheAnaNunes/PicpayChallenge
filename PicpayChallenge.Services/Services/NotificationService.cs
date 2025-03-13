using PicpayChallenge.Services.Exceptions.TransactionException;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class NotificationService(HttpClient httpClient) : INotificationService
{
    private const string _endpoint = "https://util.devi.tools/api/v1/notify";
    public async Task<HttpResponseMessage?> SendNotificationAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            try
            {
                var response = await httpClient.PostAsync(_endpoint, null);

                if (response.IsSuccessStatusCode)
                    return response;

                throw new FailedNotificationException();
            }
            catch (FailedNotificationException)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                continue;
            }
        }
        return null;
    }
}
