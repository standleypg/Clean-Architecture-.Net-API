using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.Common.Models;

namespace Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuReview(MenuReviewId menuReviewId, float rating, string comment, HostId hostId, MenuId menuId, DinnerId dinnerId, DateTime createdDatetime, DateTime updatedDatetime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        DinnerId = dinnerId;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDatetime;
    }

    public float Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }
}