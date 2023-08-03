using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;
