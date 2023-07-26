namespace Application.Services;

public interface IAuthService
{
    AuthResult Register(string firstName, string lastName, string password, string email);
    AuthResult Login(string password, string email);
}
