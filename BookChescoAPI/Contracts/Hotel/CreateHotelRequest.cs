namespace BookChescoAPI.Contracts.Hotel;

public record CreateHotelRequest(
    string Name,
    string City,
    string Address,
    string Describe
);