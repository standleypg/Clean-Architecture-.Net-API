using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public User(UserId userId, string firstName, string lastName, string email, string password) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
}
