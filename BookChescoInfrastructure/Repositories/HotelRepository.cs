using BookChescoDomain.Models;
using BookChescoInfrastructure.Services;
using BookChescoDomain.Repositories;
using MongoDB.Driver;

namespace BookChescoInfrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly IMongoCollection<Hotel> _hotelsCollection;

    public HotelRepository(MongoDbService mongoDbService)
    {
        _hotelsCollection = mongoDbService.GetCollection<Hotel>("hotels");
    }
    public async Task<List<Hotel>> GetAsync() =>
        await _hotelsCollection.Find(_ => true).ToListAsync();

    public async Task<Hotel?> GetAsync(string id) =>
        await _hotelsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Hotel newHotel) =>
        await _hotelsCollection.InsertOneAsync(newHotel);

    public async Task UpdateAsync(string id, Hotel updatedHotel) =>
        await _hotelsCollection.ReplaceOneAsync(x => x.Id == id, updatedHotel);

    public async Task RemoveAsync(string id) =>
        await _hotelsCollection.DeleteOneAsync(x => x.Id == id);
}