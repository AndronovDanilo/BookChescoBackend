namespace BookChescoDomain.Models;

public class Room : Entity
{
    public int? Number { get; set; }
    public double? Price { get; set; }
    public int? Capacity {get; set;}
    public bool? IsFree {get; set;}
    public List<Photo>? Photos { get; set; }
}