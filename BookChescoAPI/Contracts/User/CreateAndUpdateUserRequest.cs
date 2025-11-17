using BookChescoDomain.Enums;

namespace BookChescoAPI.Contracts.User;

public record CreateAndUpdateUserRequest(
    string Username,
    string Email,
    string Password,
    UserRole Role
);