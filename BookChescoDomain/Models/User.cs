using BookChescoDomain.Enums;

namespace BookChescoDomain.Models;

public class User : Entity
{
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required UserRole Role { get; set; }
    public List<Booking> Bookings { get; set; } = new();
    public string? PhotoId { get; set; }
}