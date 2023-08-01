using Domain.Common.Dinner.ValueObjects;
using Domain.Common.Host.ValueObjects;
using Domain.Common.Menu.Entities;
using Domain.Common.Menu.ValueObjects;
using Domain.Common.MenuReview.ValueObjects;
using Domain.Common.Models;

namespace Domain.Common.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{

    public Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDatetime, DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDateTime;
    }

    public readonly List<MenuSection> _menuSections = new();
    public readonly List<DinnerId> _dinnerIds = new();
    public readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();

    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }
}
