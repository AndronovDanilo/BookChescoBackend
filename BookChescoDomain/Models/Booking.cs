using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookChescoDomain.Models;

public class Booking : Entity
{
    [BsonElement("dateInRoom")]
    public DateTime? DateInRoom { get; set;}
    [BsonElement("dateOutRoom")]
    public DateTime? DateOutRoom { get; set;}
    [BsonElement("status")]
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? UserId { get; set; }
    [BsonElement("roomId")]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? RoomId { get; set; }
}

public enum BookingStatus
{
    Pending,    // ожидание подтверждения
    Confirmed,  // подтверждённое бронирование
    Cancelled,  // отменено
    Completed   // проживание завершено
}