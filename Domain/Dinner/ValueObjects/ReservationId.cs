using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects;

public sealed class ReservationId : ValueObject
{
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static ReservationId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}