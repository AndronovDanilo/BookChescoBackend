namespace BookChescoDomain.Models;

public class Photo : Entity
{
    public string Url { get; set;}
    public string PublicId { get; set;}
    public int Order { get; set;}
    
    public List<Hotel> Hotels { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
}