using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuItemId Create(Guid menuItemId)
    {
        return new(menuItemId);
    }
}
