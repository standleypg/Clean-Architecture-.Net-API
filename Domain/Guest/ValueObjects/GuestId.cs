using Domain.Common.Models;

namespace Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static GuestId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}