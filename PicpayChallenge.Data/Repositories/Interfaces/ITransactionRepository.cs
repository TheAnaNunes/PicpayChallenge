using PicpayChallenge.Data.Entities;

namespace PicpayChallenge.Data.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task SendTransactionAsync(long idSender, long idReceiver, double transactionAmount);
}
