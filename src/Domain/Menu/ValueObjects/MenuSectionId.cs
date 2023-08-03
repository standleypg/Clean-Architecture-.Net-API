using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuSectionId Create(Guid menuSectionId)
    {
        return new(menuSectionId);
    }
}
