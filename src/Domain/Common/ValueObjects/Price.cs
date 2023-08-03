using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}