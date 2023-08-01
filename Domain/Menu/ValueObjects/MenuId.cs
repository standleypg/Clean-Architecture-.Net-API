using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static MenuId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
