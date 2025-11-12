    using BookChescoDomain.Models;
    using BookChescoInfrastructure.Services;
    using BookChescoDomain.Repositories;
    using MongoDB.Driver;

    namespace BookChescoInfrastructure.Repositories;

    public class BookingRepository : IBookingRepository
    {
        private readonly IMongoCollection<Booking> _bookingsCollection;

        public BookingRepository(MongoDbService mongoDbService)
        {
            _bookingsCollection = mongoDbService.GetCollection<Booking>("bookings");
        }
        public async Task<List<Booking>> GetAsync() =>
            await _bookingsCollection.Find(_ => true).ToListAsync();

        public async Task<Booking?> GetAsync(string id) =>
            await _bookingsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Booking newBooking) =>
            await _bookingsCollection.InsertOneAsync(newBooking);

        public async Task UpdateAsync(string id, Booking updatedBooking) =>
            await _bookingsCollection.ReplaceOneAsync(x => x.Id == id, updatedBooking);

        public async Task RemoveAsync(string id) =>
            await _bookingsCollection.DeleteOneAsync(x => x.Id == id);
    }