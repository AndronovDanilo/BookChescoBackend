using BookChescoDomain.Models;

namespace BookChescoInfrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAsync();
    Task<User?> GetAsync(string id);
    Task CreateAsync(User newUser);
    Task UpdateAsync(string id, User updatedUser);
    Task RemoveAsync(string id);
}