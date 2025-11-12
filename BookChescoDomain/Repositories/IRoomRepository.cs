using BookChescoDomain.Models;

namespace BookChescoDomain.Repositories;

public interface IRoomRepository
{
    Task<List<Room>> GetAsync();
    Task<Room?> GetAsync(string id);
    Task CreateAsync(Room newRoom);
    Task UpdateAsync(string id, Room updatedRoom);
    Task RemoveAsync(string id);
}