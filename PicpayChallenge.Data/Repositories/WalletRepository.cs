using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Models;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class WalletRepository(PicpayChallengeContext context) : IWalletRepository
{
    public async Task<Wallet?> GetByIdAsync(long id) =>
        await context.Wallets
            .Include(w => w.User)
            .FirstOrDefaultAsync(w => w.Id == id);

    public async Task UpdateBalanceAsync(UpdateBalanceWallet wallet)
    {
        var existingWallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == wallet.Id);

        if (existingWallet is null)
            return;

        existingWallet.Balance = wallet.Balance;

        await context.SaveChangesAsync();
    }
}
