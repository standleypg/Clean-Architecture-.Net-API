using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Common.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{

    public MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    private readonly List<MenuItem> _items = new();
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    public string Name { get; }
    public string Description { get; }

    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}
