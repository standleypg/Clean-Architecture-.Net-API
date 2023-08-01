using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public Host(HostId hostId, string firstName, string lastName, string profileImage, string averageRating, UserId userId, DateTime createdDatetime, DateTime updatedDatetime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDatetime;
    }

    public readonly List<MenuId> _menuIds = new List<MenuId>();
    public readonly List<DinnerId> _dinnerIds = new List<DinnerId>();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public string AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }
}