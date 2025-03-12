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
    }

    public async Task<HttpResponseMessage?> GetAuthUserAsync()
    {
        var urlGet = $"https://util.devi.tools/api/v2/authorize";

        return await httpClient.GetAsync(urlGet);
    }
}
