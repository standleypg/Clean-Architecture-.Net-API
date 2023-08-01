using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId guestId, UserId userId, string lastName, string firstName, string profileImage, AverageRating averageRating, DateTime createdDatetime, DateTime updatedDatetime) : base(guestId)
    {
        UserId = userId;
        LastName = lastName;
        FirstName = firstName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDatetime;
    }

    public readonly List<DinnerId> _upcomingDinnerIds = new();
    public readonly List<DinnerId> _pastDinnerIds = new();
    public readonly List<DinnerId> _pendingDinnerIds = new();
    public readonly List<MenuReviewId> _menuReviewIds = new();
    public readonly List<Rating> _ratings = new();

    public string LastName { get; }
    public string FirstName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }

}