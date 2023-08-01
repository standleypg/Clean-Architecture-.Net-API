using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{

    public Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDatetime, DateTime updatedDateTime, List<MenuSection> menuSections) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDateTime;
        _menuSections = menuSections;
    }

    public readonly List<MenuSection> _menuSections = new();
    public readonly List<DinnerId> _dinnerIds = new();
    public readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }
    public float? AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _menuSections.AsReadOnly();

    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }

    public static Menu Create(HostId hostId, string name, string description, List<MenuSection> menuSections)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow, menuSections);
    }
}
