using Application.Common.Interfaces.Persistence;
using Domain.Menu;


namespace Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BubberDinnerDBContext _dBContext;

    public MenuRepository(BubberDinnerDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public void Add(Menu menu)
    {
        _dBContext.Menus.Add(menu);

        _dBContext.SaveChanges();
    }

    public async Task AddAsync(Menu menu)
    {
        _dBContext.Menus.Add(menu);

        await _dBContext.SaveChangesAsync();
    }

}