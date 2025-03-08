using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.Services.Exceptions.UserCreationException;
using PicpayChallenge.Services.Models;
using PicpayChallenge.Services.Services.Interface;

namespace PicpayChallenge.Services.Services;

public class UserService(IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;
    public async Task CreateUserAsync(User user)
    {
        if (user.Document.Length != 14 && user.Document.Length != 11)
        {
            throw new InvalidDocumentException();
        }
        else
        {
           await _repository.CreateUserAsync(user);
        }
    }

    public async Task<UserModel?> GetUserIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user is not null)
            return new UserModel(user.Name, user.Email, user.Wallet.Balance);

        return null;
    }
}
