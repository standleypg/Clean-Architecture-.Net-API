using Application.Authentication.Common;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Domain;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.Login;

public class LoginQueryHanlder : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHanlder(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //1. check user if exists
        if(_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Auth.InvalidCredentials();

        //2. validate password is correct
        if(user.Password != query.Password)
            return new[] {Errors.Auth.InvalidCredentials()};//just an example of returning list of errors

        //3. create JwtToken
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
