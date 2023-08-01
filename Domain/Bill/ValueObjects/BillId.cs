using Domain.Common.Models;

namespace Domain.Bill.ValueObjects;

public sealed class BillId : ValueObject
{
    private BillId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static BillId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}