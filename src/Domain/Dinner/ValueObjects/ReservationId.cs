using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects;

public sealed class ReservationId : AggregateRootId<Guid>
{
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }
    public static ReservationId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}