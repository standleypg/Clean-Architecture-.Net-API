using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Domain;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthResult Login(string password, string email)
    {
        //1. check user if exists
        if(_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User does not exist");

        //2. validate password is correct
        if(user.Password != password)
            throw new Exception("Password is incorrect");

        //3. create JwtToken
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }

    public AuthResult Register(string firstName, string lastName, string password, string email)
    {
        //1. check user if already exists
        if(_userRepository.GetUserByEmail(email) != null)
            throw new Exception("User already exists");

        //2. create user (generate id)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //3. create JwtToken
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}
