using Domain.Common.Models;

namespace Domain.Guest.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }
    public static GuestId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}