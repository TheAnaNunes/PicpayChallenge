using PicpayChallenge.Data.Models;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.Services.Models;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class WalletService(IWalletRepository repository) : IWalletService
{
    public async Task<WalletModel?> GetByIdAsync(long id)
    {
        var wallet = await repository.GetByIdAsync(id);

        if (wallet is null)
            return null;

        return new WalletModel(wallet.User.Name, wallet.Balance);
    }

    public Task UpdateBalanceAsync(UpdateBalanceWallet wallet) =>
        repository.UpdateBalanceAsync(wallet);
}
