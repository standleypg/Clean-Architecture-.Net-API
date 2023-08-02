using Application.Common.Interfaces.Persistence;
using Domain.User;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email) ?? null;
    }
}
