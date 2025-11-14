namespace BookChescoAPI.Contracts.User;

public record RegistrationUserRequest (
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
    );