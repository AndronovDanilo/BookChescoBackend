namespace BookChescoAPI.Contracts.User;

public record LoginUserRequest (
    string UsernameOrEmail,
    string Password
    );