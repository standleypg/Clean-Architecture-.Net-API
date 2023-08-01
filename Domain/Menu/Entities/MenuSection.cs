using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{

    public MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuSectionItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    private readonly List<MenuSectionItem> _items = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuSectionItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuSectionItem> items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }
}
