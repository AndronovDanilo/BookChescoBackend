using BookChescoAPI.Contracts.Booking;
using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookChescoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;

    public BookingsController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _bookingRepository.GetAsync();
        return Ok(bookings);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var booking = await _bookingRepository.GetAsync(id);
        if (booking is null)
            return NotFound();

        return Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAndUpdateBookingRequest request)
    {
        var newBooking = new Booking
        {
            UserId = request.UserId,
            RoomId = request.RoomId,
            DateInRoom = request.DateInRoom,
            DateOutRoom = request.DateOutRoom,
            IsPaid = request.IsPaid,
            Amount = request.Amount,
            Status = request.Status
        };

        await _bookingRepository.CreateAsync(newBooking);

        return CreatedAtAction(nameof(GetById), new { id = newBooking.Id }, newBooking);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateAndUpdateBookingRequest request)
    {
        var existingBooking = await _bookingRepository.GetAsync(id);
        if (existingBooking is null)
            return NotFound();

        existingBooking.UserId = request.UserId;
        existingBooking.RoomId = request.RoomId;
        existingBooking.DateInRoom = request.DateInRoom;
        existingBooking.DateOutRoom = request.DateOutRoom;
        existingBooking.IsPaid = request.IsPaid;
        existingBooking.Amount = request.Amount;
        existingBooking.Status = request.Status;

        await _bookingRepository.UpdateAsync(id, existingBooking);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingBooking = await _bookingRepository.GetAsync(id);
        if (existingBooking is null)
            return NotFound();
        
        await _bookingRepository.RemoveAsync(id);
        return NoContent();
    }
}