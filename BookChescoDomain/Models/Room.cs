namespace BookChescoDomain.Models;

public class Room : Entity
{
    public int? Number { get; set; }
    public double? Price { get; set; }
    public int? Capacity {get; set;}
    public bool? IsFree {get; set;}
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public List<Booking> Bookings { get; set; } = new();
    public List<Photo> Photos { get; set; } = new();
}