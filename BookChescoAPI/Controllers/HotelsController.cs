using Microsoft.AspNetCore.Mvc;
using BookChescoAPI.Contracts.Hotel;
using BookChescoDomain.Repositories;
using BookChescoDomain.Models;
namespace BookChescoAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;
    
    public HotelsController(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
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
        var existing = await _hotelRepository.GetAsync(id);
        if (existing is null)
            return NotFound();
        existing.Name = request.Name;
        existing.City = request.City;
        existing.Address = request.Address;
        existing.Describe = request.Describe;
        await _hotelRepository.UpdateAsync(id, existing);
        return Ok(existing);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _hotelRepository.GetAsync(id);
        if (existing is null)
            return NotFound();

        await _hotelRepository.RemoveAsync(id);
        return Ok($"Hotel with id {id} deleted");
    }
}