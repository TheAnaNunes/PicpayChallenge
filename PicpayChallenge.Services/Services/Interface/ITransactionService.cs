namespace PicpayChallenge.Services.Services.Interface;

public interface ITransactionService
{
    Task SendTransactionAsync(long idSender, long idReceiver, double transactionAmount);
}
