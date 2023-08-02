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
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}
