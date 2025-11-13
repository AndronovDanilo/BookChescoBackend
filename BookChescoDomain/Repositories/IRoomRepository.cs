using BookChescoDomain.Models;

namespace BookChescoDomain.Repositories;

public interface IRoomRepository
{
    Task<List<Room>> GetAsync();
    Task<Room?> GetAsync(int id);
    Task CreateAsync(Room newRoom);
    Task UpdateAsync(int id, Room updatedRoom);
    Task RemoveAsync(int id);
}