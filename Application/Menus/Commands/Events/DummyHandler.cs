using Domain.Menu.Events;
using MediatR;

namespace Application.Menus.Commands.Events;

public class DummyHandler : INotificationHandler<MenuCreatedEvent>
{
    public Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

}