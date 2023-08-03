using Domain.Bill.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Bill;

public sealed class Bill : AggregateRoot<BillId, Guid>
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

    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Price { get; private set; }
    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }
}