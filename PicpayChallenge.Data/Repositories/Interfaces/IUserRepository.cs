using PicpayChallenge.Data.Entities;

namespace PicpayChallenge.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User?> GetByIdAsync(long id);
}
