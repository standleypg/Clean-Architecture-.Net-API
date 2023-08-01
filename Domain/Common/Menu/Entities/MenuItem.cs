using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Common.Menu.Entities;

public sealed class MenuItem :Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }   
    public string Name { get; }
    public string Description { get; }
    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
