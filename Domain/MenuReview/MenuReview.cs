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

    public float Rating { get; private set; }
    public string Comment { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }
}