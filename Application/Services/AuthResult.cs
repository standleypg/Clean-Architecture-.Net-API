using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Services;

public record AuthResult
(
    User User,
    string Token
);
