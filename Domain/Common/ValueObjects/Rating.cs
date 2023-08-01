using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class Rating : AggregateRoot<RatingId>
{
    public Rating(RatingId ratingId, HostId hostId, DinnerId dinnerId, int value, DateTime createdDatetime, DateTime updatedDatetime) : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Value = value;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDatetime;
    }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int Value { get; }
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }
}

public sealed class RatingId : ValueObject
{
    private RatingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static RatingId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
