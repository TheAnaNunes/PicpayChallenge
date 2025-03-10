using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class TransactionRepository(PicpayChallengeContext context) : ITransactionRepository
{
    public async Task SendTransactionAsync(
        User sender,
        User receiver,
        double transactionAmount)
    {
        sender.Wallet.Balance -= transactionAmount;
        receiver.Wallet.Balance += transactionAmount;

        await context.SaveChangesAsync();
    }
}
