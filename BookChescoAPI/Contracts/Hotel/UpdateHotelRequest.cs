namespace BookChescoAPI.Contracts.Hotel;

public record UpdateHotelRequest(
    string? Name,
    string? City,
    string? Address,
    string? Describe
);
