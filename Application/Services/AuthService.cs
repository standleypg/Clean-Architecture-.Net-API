using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Services;

public class AuthService : IAuthService
{
    public AuthResult Login(string password, string email)
    {
        return new AuthResult(Guid.NewGuid(), "John", "Doe", email, "token");
    }

    public AuthResult Register(string firstName, string lastName, string password, string email)
    {
        return new AuthResult(Guid.NewGuid(), firstName, lastName, email, "token");
    }
}
