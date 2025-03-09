using Microsoft.AspNetCore.Mvc;
using PicpayChallenge.Data.Models;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.EndPoints;

public static class WalletExtensions
{
    public static void AddWalletEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/wallets").WithTags("Wallet");

        endpoints.MapGet("/{id:long}", async (
            [FromServices] IWalletService service,
            long id) =>
        {
            var wallet = await service.GetByIdAsync(id);

            return wallet is not null 
                ? Results.Ok(wallet) : 
                Results.NotFound();
        });

        endpoints.MapPatch("/balance", async (
            [FromServices] IWalletService service,
            [FromBody] UpdateBalanceWallet wallet) =>
        {
            await service.UpdateBalanceAsync(wallet);

            return Results.NoContent();
        });
    }
}
