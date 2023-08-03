using Domain.Common.Models;

namespace Domain.Menu.Events;

public record MenuCreatedEvent(Menu Menu) : IDomainEvent;