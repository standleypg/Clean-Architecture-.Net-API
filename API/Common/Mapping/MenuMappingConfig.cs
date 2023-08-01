using Application.Menus.Commands.CreateMenu;
using Contracts.Menus;
using Domain.Menu;
using Domain.Menu.Entities;
using Mapster;

namespace API.Common.Mapping;

using MenuSection = Domain.Menu.Entities.MenuSection;
public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(d => d.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuSectionItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }

}