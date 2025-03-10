using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.Services.Exceptions.UserCreationException;
using PicpayChallenge.Services.Models;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task CreateUserAsync(User user)
    {
        if (user.Document.Length != 14 && user.Document.Length != 11)
            throw new InvalidDocumentException();
        else
           await repository.CreateUserAsync(user);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var user = await repository.GetByIdAsync(id);

        if (user is not null)
            await repository.DeleteByUserAsync(user);
        else
            throw new KeyNotFoundException("User not found");
    }

    public async Task<UserModel?> GetUserIdAsync(long id)
    {
        var user = await repository.GetByIdAsync(id);

        if (user is not null)
            return new UserModel(user.Name, user.Email, user.Wallet.Balance);

        return null;
    }
}
