using System.Reflection;
using Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class BubberDinnerDBContext : DbContext
{
    public BubberDinnerDBContext(DbContextOptions<BubberDinnerDBContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BubberDinnerDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}