using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Models;

namespace PicpayChallenge.Data.Repositories.Interfaces;

public interface IWalletRepository
{
    Task<Wallet?> GetByIdAsync(long id);
    Task UpdateBalanceAsync(UpdateBalanceWallet wallet);
}
