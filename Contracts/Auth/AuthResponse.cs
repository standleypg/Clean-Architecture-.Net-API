namespace Contracts;

public record AuthResponse
(
    Guid id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
