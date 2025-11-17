using BookChescoDomain.Enums;

namespace BookChescoAPI.Contracts.Booking;

public record CreateAndUpdateBookingRequest(
    DateTime DateInRoom,
    DateTime DateOutRoom,
    bool IsPaid,
    double Amount,
    int RoomId,
    int UserId,
    BookingStatus Status);