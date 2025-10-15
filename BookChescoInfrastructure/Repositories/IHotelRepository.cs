﻿using BookChescoDomain.Models;

namespace BookChescoInfrastructure.Repositories;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAsync();
    Task<Hotel?> GetAsync(string id);
    Task CreateAsync(Hotel newHotel);
    Task UpdateAsync(string id, Hotel updatedHotel);
    Task RemoveAsync(string id);
}