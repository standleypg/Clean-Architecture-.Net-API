using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuId Create(Guid value) => new(value);
}
