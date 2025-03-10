using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.Services.Exceptions.TransactionException;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class TransactionService(
    ITransactionRepository transactionRepository, 
    IUserRepository userRepository) 
    : ITransactionService
{
    public async Task SendTransactionAsync(
        long idSender, 
        long idReceiver, 
        double transactionAmount)
    {
        var userSender = await userRepository.GetByIdAsync(idSender) 
            ?? throw new InvalidUserException("Sender User not found!");

        if (userSender.Document.Length != 11)
            throw new InvalidSenderException();

        var userReceiver = await userRepository.GetByIdAsync(idReceiver)
            ?? throw new InvalidUserException("Receiver User not found!");

        if (userSender.Wallet.Balance < transactionAmount)
            throw new NoBalanceException();

        if (userSender.Equals(userReceiver))
            throw new InvalidUserException();

        await transactionRepository
            .SendTransactionAsync(userSender, userReceiver, transactionAmount);
    }
}
