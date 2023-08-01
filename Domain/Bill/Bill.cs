using Domain.Bill.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdDatetime, DateTime updatedDateTime) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDateTime;
    }

    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }
}