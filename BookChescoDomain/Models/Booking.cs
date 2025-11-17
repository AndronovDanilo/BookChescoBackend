using BookChescoDomain.Enums;

namespace BookChescoDomain.Models;

public class Booking : Entity
{
    public DateTime? DateInRoom { get; set;}
    public DateTime? DateOutRoom { get; set;}
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public bool? IsPaid { get; set; }
    public double? Amount { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
}