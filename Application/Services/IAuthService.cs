using ErrorOr;

namespace Application.Services;

public interface IAuthService
{
    ErrorOr<AuthResult> Register(string firstName, string lastName, string password, string email);
    ErrorOr<AuthResult> Login(string password, string email);
}
