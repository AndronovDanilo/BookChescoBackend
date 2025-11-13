using BookChescoDomain.Models;

namespace BookChescoDomain.Repositories;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAsync();
    Task<Hotel?> GetAsync(int id);
    Task CreateAsync(Hotel newHotel);
    Task UpdateAsync(int id, Hotel updatedHotel);
    Task RemoveAsync(int id);
}