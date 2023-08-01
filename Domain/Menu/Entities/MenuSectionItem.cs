using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Menu.Entities;

public sealed class MenuSectionItem : Entity<MenuItemId>
{
    private MenuSectionItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; }
    public string Description { get; }
    public static MenuSectionItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
