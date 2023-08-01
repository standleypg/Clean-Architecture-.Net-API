using Domain.Common.Models;

namespace Domain.Common.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
