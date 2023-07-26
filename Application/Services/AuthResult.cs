using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services;

public record AuthResult
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
