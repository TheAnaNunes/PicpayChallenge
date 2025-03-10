using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class UserRepository(PicpayChallengeContext context) : IUserRepository
{
    public async Task CreateUserAsync(User user)
    {
        await context.Users.AddAsync(user);

        await context.SaveChangesAsync();
    }
    public async Task DeleteByUserAsync(User user)
    {
        context.Remove(user);
        await context.SaveChangesAsync();
    }
    public async Task<User?> GetByIdAsync(long id) =>
        await context.Users
        .Include(u => u.Wallet)
        .FirstOrDefaultAsync(u => u.Id == id);
}
