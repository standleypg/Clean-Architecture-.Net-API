using Domain.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Menu.Entities;

public sealed class MenuSections : Entity<MenuSectionId>
{

    public MenuSections(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    private MenuSections() { }

    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSections Create(string name, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }
}
