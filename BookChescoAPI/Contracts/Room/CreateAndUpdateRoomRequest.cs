namespace BookChescoAPI.Contracts.Room;

public record CreateAndUpdateRoomRequest(
    int? Number,
    double? Price,
    string? Type,
    int? Capacity,
    bool? IsFree
);