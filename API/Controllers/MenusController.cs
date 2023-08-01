using Application.Menus.Commands.CreateMenu;
using Contracts.Menus;
using Domain.Menu;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[AllowAnonymous]
[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu([FromBody] CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        ErrorOr<Menu> createdMenuResult = await _mediator.Send(command);

        var test = _mapper.Map<MenuResponse>(createdMenuResult);
        return createdMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );
    }

    protected async Task<IActionResult> GetMenu(string hostId, string menuId)
    {
        return Ok();
    }
}