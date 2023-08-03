using Application.Common.Interfaces.Persistence;
using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. create menu
        var menu = Menu.Create(
            HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(s =>
                MenuSections.Create(
                    name: s.Name,
                    description: s.Description,
                    items: s.Items.ConvertAll(i =>
                        MenuItem.Create(
                            name: i.Name,
                            description: i.Description
                        )
                    )
                ))
            );

        // 2. Persist menu
        _menuRepository.Add(menu);

        // 3. return menu

        return menu;
    }
}