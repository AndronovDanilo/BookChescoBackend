using MongoDB.Bson.Serialization.Attributes;

namespace BookChescoDomain.Models;

public class Room : Entity
{
    [BsonElement("number")]
    public int? Number { get; set; }
    [BsonElement("price")]
    public double? Price { get; set; }
    [BsonElement("capacity")]
    public int? Capacity {get; set;}
    [BsonElement("isfree")]
    public bool? IsFree {get; set;}
    [BsonElement("photos")]
    public List<Photo>? Photos { get; set; }
}