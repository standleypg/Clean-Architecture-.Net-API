using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Password,
    string Email
) : IRequest<ErrorOr<AuthenticationResult>>;
