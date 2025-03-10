using Microsoft.AspNetCore.Mvc;
using PicpayChallenge.Services.Models;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.EndPoints;

public static class TransactionExtensions
{
    public static void AddTransactionsEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/transactions").WithTags("Transactions");

        endpoints.MapPost("", async (
            [FromServices] ITransactionService service,
            TransactionModel transactionInformation) =>
        {
            await service.SendTransactionAsync(
                transactionInformation.IdSender,
                transactionInformation.IdReceiver,
                transactionInformation.TransactionAmount);

            Results.Ok();
        });
    }
}
