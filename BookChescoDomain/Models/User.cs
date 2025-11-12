namespace BookChescoDomain.Models;

public class User : Entity
{
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required UserRole Role { get; set; }
    public string? HotelId { get; set; }
    public string? PhotoId { get; set; }
}

public enum UserRole
{
    Admin,        
    HotelOwner,   
    Manager,      
    Client,       
    Guest         
}