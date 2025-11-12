using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookChescoInfrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Booking>> GetAsync() =>
        await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Booking?> GetAsync(int id) =>
        await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

    public async Task CreateAsync(Booking newBooking)
    {
        _context.Bookings.Add(newBooking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Booking updatedBooking)
    {
        updatedBooking.Id = id;
        _context.Bookings.Update(updatedBooking);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var existing = await _context.Bookings.FindAsync(id);
        if (existing is null) return;
        _context.Bookings.Remove(existing);
        await _context.SaveChangesAsync();
    }
}
