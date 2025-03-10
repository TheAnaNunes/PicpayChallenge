using PicpayChallenge.Data.Entities;

namespace PicpayChallenge.Data.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task SendTransactionAsync(User sender, User receiver, double transactionAmount);
}
