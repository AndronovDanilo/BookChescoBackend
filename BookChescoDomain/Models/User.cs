using MongoDB.Bson.Serialization.Attributes; 

namespace BookChescoDomain.Models;

public class User : Entity
{
    [BsonElement("login")]
    public string? Login { get; set; }
    [BsonElement("password")]
    public string? Password { get; set; }
    [BsonElement("email")]
    public string? Email { get; set; }
    [BsonElement("role")]
    public UserRole Role { get; set; }
    [BsonElement("hotelId")]
    public string? HotelId { get; set; }
    [BsonElement("photos")]
    public Photo? Photos { get; set; }
}

public enum UserRole
{
    Admin,        
    HotelOwner,   
    Manager,      
    Client,       
    Guest         
}