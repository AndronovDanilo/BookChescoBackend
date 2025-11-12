using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookChescoInfrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext _context;

    public HotelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAsync() =>
        await _context.Hotels
            .AsNoTracking()
            .ToListAsync();

    public async Task<Hotel?> GetAsync(int id) =>
        await _context.Hotels
            .Include(h => h.Rooms)
            .Include(h => h.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id);

    public async Task CreateAsync(Hotel newHotel)
    {
        _context.Hotels.Add(newHotel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Hotel updatedHotel)
    {
        updatedHotel.Id = id;
        _context.Hotels.Update(updatedHotel);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var existing = await _context.Hotels.FindAsync(id);
        if (existing is null) return;
        _context.Hotels.Remove(existing);
        await _context.SaveChangesAsync();
    }
}