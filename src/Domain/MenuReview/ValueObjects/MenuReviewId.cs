using Domain.Common.Models;

namespace Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }
    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}