using API.Filters;
using Application.Services;
using Contracts;
using Contracts.Auth;
using Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        ErrorOr<AuthResult> authResult = _authService.Register(request.FirstName, request.LastName, request.Password, request.Email);
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        ErrorOr<AuthResult> authResult = _authService.Login(request.Password, request.Email);

        if(authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials())
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }
    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        return new AuthResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
    }

}
