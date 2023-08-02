using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}