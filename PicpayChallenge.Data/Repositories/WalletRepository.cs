using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Models;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class WalletRepository(PicpayChallengeContext context) : IWalletRepository
{
    private readonly PicpayChallengeContext _context = context;

    public async Task<Wallet?> GetByIdAsync(long id) =>
        await _context.Wallets
            .Include(w => w.User)
            .FirstOrDefaultAsync(w => w.Id == id);

    public async Task UpdateBalanceAsync(UpdateBalanceWallet wallet)
    {
        var existingWallet = await _context.Wallets.FirstOrDefaultAsync(w => w.Id == wallet.Id);

        if (existingWallet is null)
            return;

        existingWallet.Balance = wallet.Balance;

        await _context.SaveChangesAsync();
    }
}
