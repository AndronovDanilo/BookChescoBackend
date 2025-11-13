namespace BookChescoDomain.Models;

public class Photo : Entity
{
    public required string Url { get; set; }
    public required string PublicId { get; set; }
    public int Order { get; set; } = 0;
    
    public List<Hotel> Hotels { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
}