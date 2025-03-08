using PicpayChallenge.Data.Entities;
using PicpayChallenge.Services.Models;

namespace PicpayChallenge.Services.Services.Interface;

public interface IUserService
{
    Task<UserModel?> GetUserIdAsync(long id);
    Task CreateUserAsync(User user);
}
