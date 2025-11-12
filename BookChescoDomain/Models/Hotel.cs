namespace BookChescoDomain.Models;

public class Hotel : Entity
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Address {get; set;}
    public string? Describe { get; set;}
    public float? Rate { get; set;}
    public List<Photo>? Photos { get; set;}
}