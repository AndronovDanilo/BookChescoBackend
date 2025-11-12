namespace BookChescoDomain.Models;

public class Booking : Entity
{
    public DateTime? DateInRoom { get; set;}
    public DateTime? DateOutRoom { get; set;}
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
}

public enum BookingStatus
{
    Pending,    // ожидание подтверждения
    Confirmed,  // подтверждено бронирование
    Cancelled,  // отменено
    Completed   // проживание завершено
}