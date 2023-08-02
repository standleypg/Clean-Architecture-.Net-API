using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{

    public Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDatetime, DateTime updatedDateTime, AverageRating averageRating, List<MenuSections> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDateTime;
        _sections = sections;
        AverageRating = averageRating;
    }

    public readonly List<MenuSections> _sections = new();
    public readonly List<DinnerId> _dinnerIds = new();
    public readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating? AverageRating { get; private set; }
    public IReadOnlyList<MenuSections> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }

    public static Menu Create(HostId hostId, string name, string description, List<MenuSections> sections)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow, AverageRating.CreateNew(), sections ?? new());
    }

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618
}
