using BookChescoAPI.Contracts.Room;
using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookChescoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;
    private readonly ICloudinaryService _cloudinaryService;

    public RoomsController(
        IRoomRepository roomRepository,
        ICloudinaryService cloudinaryService
    )
    {
        _roomRepository = roomRepository;
        _cloudinaryService = cloudinaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _roomRepository.GetAsync();
        return Ok(rooms);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var room = await _roomRepository.GetAsync(id);
        if (room is null)
            return NotFound();
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAndUpdateRoomRequest request)
    {
        var newRoom = new Room
        {
            Number = request.Number,
            Price = request.Price,
            Type = request.Type,
            Capacity = request.Capacity,
            IsFree = request.IsFree
        };

        await _roomRepository.CreateAsync(newRoom);
        
        return CreatedAtAction(nameof(GetById), new { id = newRoom.Id }, newRoom);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateAndUpdateRoomRequest request)
    {
        var existingRoom = await _roomRepository.GetAsync(id);
        if (existingRoom is null)
            return NotFound();
        existingRoom.Number = request.Number;
        existingRoom.Price = request.Price;
        existingRoom.Type = request.Type;
        existingRoom.Capacity = request.Capacity;
        existingRoom.IsFree = request.IsFree;
        await _roomRepository.UpdateAsync(id, existingRoom);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingRoom = await _roomRepository.GetAsync(id);
        if (existingRoom is null)
            return NotFound();
        await _roomRepository.RemoveAsync(id);
        return NoContent();
    }
}