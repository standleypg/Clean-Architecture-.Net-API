using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Menu.ValueObjects;
using Domain.Common.Models;

namespace Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }
    private MenuItem() { }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}
