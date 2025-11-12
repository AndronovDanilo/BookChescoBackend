using BookChescoDomain.Models;

namespace BookChescoDomain.Repositories;

public interface IBookingRepository
{
    Task<List<Booking>> GetAsync();
    Task<Booking?> GetAsync(int id);
    Task CreateAsync(Booking newBooking);
    Task UpdateAsync(int id, Booking updatedBooking);
    Task RemoveAsync(int id);
}