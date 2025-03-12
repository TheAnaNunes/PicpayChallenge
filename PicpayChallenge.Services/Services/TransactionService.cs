using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.Services.Exceptions.TransactionException;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class TransactionService(
    ITransactionRepository transactionRepository, 
    IUserRepository userRepository,
    HttpClient httpClient) 
    : ITransactionService
{
    public async Task SendTransactionAsync(
        long idSender, 
        long idReceiver, 
        double transactionAmount
        )
    {
        var userSender = await userRepository.GetByIdAsync(idSender) 
            ?? throw new InvalidUserException("Sender User not found!");

        var statusCode = await GetAuthUserAsync();

        if (userSender.Document.Length != 11)
            throw new InvalidSenderException();

        var userReceiver = await userRepository.GetByIdAsync(idReceiver)
            ?? throw new InvalidUserException("Receiver User not found!");

        if (userSender.Wallet.Balance < transactionAmount)
            throw new NoBalanceException();

        if (userSender.Equals(userReceiver))
            throw new InvalidUserException();

        if (statusCode is null || !statusCode.IsSuccessStatusCode)
            throw new FailedAuthenticationException();

        await transactionRepository
            .SendTransactionAsync(userSender.Id, userReceiver.Id, transactionAmount);


        for (int i = 0; i < 3; i++)
        {
            try
            {
                var response = await SendNotificationAsync();

                if (response is null || !response.IsSuccessStatusCode)
                    throw new FailedNotificationException();

                return;
            }
            catch (Exception)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                continue;
            }
        }
    }

    public async Task<HttpResponseMessage?> GetAuthUserAsync()
    {
        return await httpClient.GetAsync("https://util.devi.tools/api/v2/authorize");
    }

    public async Task<HttpResponseMessage?> SendNotificationAsync()
    {
        return await httpClient.PostAsync("https://util.devi.tools/api/v1/notify", null);
    }
}
