namespace PicpayChallenge.Services.Services.Interface;

public interface INotificationService
{
    Task<HttpResponseMessage?> SendNotificationAsync();
}
