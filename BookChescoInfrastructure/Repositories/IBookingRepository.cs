using BookChescoDomain.Models;

namespace BookChescoInfrastructure.Repositories;

public interface IBookingRepository
{
    Task<List<Booking>> GetAsync();
    Task<Booking?> GetAsync(string id);
    Task CreateAsync(Booking newBooking);
    Task UpdateAsync(string id, Booking updatedBooking);
    Task RemoveAsync(string id);
}