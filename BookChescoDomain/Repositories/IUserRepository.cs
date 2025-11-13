using BookChescoDomain.Models;

namespace BookChescoDomain.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAsync();
    Task<User?> GetAsync(int id);
    Task CreateAsync(User newUser);
    Task UpdateAsync(int id, User updatedUser);
    Task RemoveAsync(int id);
}