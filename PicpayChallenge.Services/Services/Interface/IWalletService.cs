using PicpayChallenge.Data.Models;
using PicpayChallenge.Services.Models;

namespace PicpayChallenge.Services.Services.Interface;

public interface IWalletService
{
    Task<WalletModel?> GetByIdAsync(long id);
    Task UpdateBalanceAsync(UpdateBalanceWallet wallet);
}
