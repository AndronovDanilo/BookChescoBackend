using BookChescoAPI.Contracts.Hotel;
using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookChescoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ICloudinaryService _cloudinaryService;

    public HotelsController(
        IHotelRepository hotelRepository,
        ICloudinaryService cloudinaryService
    )
    {
        _hotelRepository = hotelRepository;
        _cloudinaryService = cloudinaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hotels = await _hotelRepository.GetAsync();
        return Ok(hotels);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var hotel = await _hotelRepository.GetAsync(id);
        if (hotel is null)
            return NotFound();

        return Ok(hotel);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHotelRequest request)
    {
        var newHotel = new Hotel
        {
            Name = request.Name,
            City = request.City,
            Address = request.Address,
            Describe = request.Describe
        };

        await _hotelRepository.CreateAsync(newHotel);

        return CreatedAtAction(nameof(GetById), new { id = newHotel.Id }, newHotel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateHotelRequest request)
    {
        var existingHotel = await _hotelRepository.GetAsync(id);
        if (existingHotel is null)
            return NotFound();
        existingHotel.Name = request.Name;
        existingHotel.City = request.City;
        existingHotel.Address = request.Address;
        existingHotel.Describe = request.Describe;
        await _hotelRepository.UpdateAsync(id, existingHotel);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingHotel = await _hotelRepository.GetAsync(id);
        if (existingHotel is null)
            return NotFound();

        await _hotelRepository.RemoveAsync(id);
        return NoContent();
    }
}