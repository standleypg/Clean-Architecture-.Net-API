using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.Host;

public sealed class Host : AggregateRoot<HostId, Guid>
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

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public string AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }
}