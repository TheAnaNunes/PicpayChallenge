using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class TransactionRepository(PicpayChallengeContext context) : ITransactionRepository
{
    public async Task SendTransactionAsync(
        long idSender,
        long idReceiver,
        double transactionAmount)
    {
        var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            await context.Wallets
                .Where(w => w.UserId == idSender)
                .ExecuteUpdateAsync(setter => 
                    setter.SetProperty(w => w.Balance, w => w.Balance - transactionAmount));

            await context.Wallets
                .Where(w => w.UserId == idReceiver)
                .ExecuteUpdateAsync(setter => 
                    setter.SetProperty(w => w.Balance, w => w.Balance + transactionAmount));

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();

            throw;
        }
    }
}
