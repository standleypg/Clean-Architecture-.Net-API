using Domain.Common.Models;

namespace Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}