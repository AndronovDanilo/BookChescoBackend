namespace BookChescoDomain.Models;

public class Booking : Entity
{
    public DateTime? DateInRoom { get; set;}
    public DateTime? DateOutRoom { get; set;}
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public string? UserId { get; set; }
    public string? RoomId { get; set; }
}

public enum BookingStatus
{
    Pending,    // ожидание подтверждения
    Confirmed,  // подтверждённое бронирование
    Cancelled,  // отменено
    Completed   // проживание завершено
}