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
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public int Value { get; private set; }
    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }
}

public sealed class RatingId : ValueObject
{
    private RatingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static RatingId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
