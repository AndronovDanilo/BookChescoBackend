using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookChescoInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAsync() =>
        await _context.Users
            .Include(u => u.Bookings)
            .AsNoTracking()
            .ToListAsync();

    public async Task<User?> GetAsync(int id) =>
        await _context.Users
            .Include(u => u.Bookings)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task CreateAsync(User newUser)
    {
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, User updatedUser)
    {
        updatedUser.Id = id;
        _context.Users.Update(updatedUser);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var existing = await _context.Users.FindAsync(id);
        if (existing is null) return;
        _context.Users.Remove(existing);
        await _context.SaveChangesAsync();
    }
}
