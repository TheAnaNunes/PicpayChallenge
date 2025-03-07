using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Entities;
using PicpayChallenge.Data.Repositories.Interfaces;

namespace PicpayChallenge.Data.Repositories;

public class UserRepository(PicpayChallengeContext context) : IUserRepository
{
    private readonly PicpayChallengeContext _context = context;

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(long id) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
}
