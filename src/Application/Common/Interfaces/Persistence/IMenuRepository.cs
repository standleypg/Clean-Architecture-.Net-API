using Domain.Menu;

namespace Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
    Task AddAsync(Menu menu);
}