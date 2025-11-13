using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookChescoInfrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Room>> GetAsync() =>
        await _context.Rooms
            .Include(r => r.Photos)
            .Include(r => r.Bookings)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Room?> GetAsync(int id) =>
        await _context.Rooms
            .Include(r => r.Photos)
            .Include(r => r.Bookings)
            .Include(r => r.Hotel)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task CreateAsync(Room newRoom)
    {
        _context.Rooms.Add(newRoom);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Room updatedRoom)
    {
        updatedRoom.Id = id;
        _context.Rooms.Update(updatedRoom);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var existing = await _context.Rooms.FindAsync(id);
        if (existing is null) return;
        _context.Rooms.Remove(existing);
        await _context.SaveChangesAsync();
    }
}
