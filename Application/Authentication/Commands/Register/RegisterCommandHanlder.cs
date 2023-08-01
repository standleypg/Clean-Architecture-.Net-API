using Application.Authentication.Common;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Domain;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandHanlder : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHanlder(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. check user if already exists
        if (_userRepository.GetUserByEmail(command.Email) != null)
            return Errors.User.DuplicateEmail();

        // 2. create user (generate id)
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
        };

        _userRepository.Add(user);

        // 3. create JwtToken
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
