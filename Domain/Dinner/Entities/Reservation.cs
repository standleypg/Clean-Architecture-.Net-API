using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Enum;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;

namespace Domain.Dinner.Entities;

public sealed class Reservation : AggregateRoot<ReservationId>
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

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public Status Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDatetime { get; }

}