using Microsoft.AspNetCore.Mvc;
using PicpayChallenge.Data.Models;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.EndPoints;

public static class WalletExtensions
{
    public static void AddWalletEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/wallets").WithTags("Wallet");

        endpoints.MapGet("/{id:long}", async (
            [FromServices] IWalletRepository repository,
            long id) =>
        {
            var wallet = await repository.GetByIdAsync(id);

            return wallet is not null 
                ? Results.Ok(wallet) : 
                Results.NotFound();
        });

        endpoints.MapPatch("/balance", async (
            [FromServices] IWalletRepository repository,
            [FromBody] UpdateBalanceWallet wallet) =>
        {
            await repository.UpdateBalanceAsync(wallet);

            return Results.NoContent();
        });
    }
}
