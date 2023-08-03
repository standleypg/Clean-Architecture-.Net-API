using Domain.Common.Models;

namespace Domain.Bill.ValueObjects;

public sealed class BillId : AggregateRootId<Guid>
{
    private BillId(Guid value)
    {
        Value = value;
    }
    public override Guid Value { get; protected set; }
    public static BillId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}