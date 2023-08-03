using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Enum;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;

namespace Domain.Dinner.Entities;

public sealed class Reservation : AggregateRoot<ReservationId, Guid>
{
    public Reservation(ReservationId reservationId, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, Status status, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location, DateTime createdDatetime, DateTime updatedDatetime) : base(reservationId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDatetime = createdDatetime;
        UpdatedDatetime = updatedDatetime;
    }

    public readonly List<Reservation> _reservations = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime StartedDateTime { get; private set; }
    public DateTime EndedDateTime { get; private set; }
    public Status Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDatetime { get; private set; }
    public DateTime UpdatedDatetime { get; private set; }

}