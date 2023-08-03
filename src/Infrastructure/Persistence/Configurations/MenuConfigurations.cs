using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, ri =>
        {

            ri.ToTable("MenuReviewIds");

            ri.WithOwner().HasForeignKey("MenuId");

            ri.HasKey("Id");

            ri.Property(r => r.Value)
            .HasColumnName("ReviewId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, di =>
        {

            di.ToTable("MenuDinnerIds");

            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");

            di.Property(dinnerId => dinnerId.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey("Id", "MenuId");

            sb.Property(menuSection => menuSection.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuSectionId.Create(value)
            );

            sb.Property(s => s.Name)
            .HasMaxLength(100);

            sb.Property(s => s.Description)
            .HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey("Id", "MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                .HasColumnName("MenuItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value)
                );

                ib.Property(s => s.Name)
                .HasMaxLength(100);

                ib.Property(s => s.Description)
                .HasMaxLength(100);
            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(menu => menu.Id);

        builder.Property(menu => menu.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => MenuId.Create(value)
        );

        builder.Property(menu => menu.Name)
        .HasMaxLength(100);

        builder.Property(menu => menu.Description)
        .HasMaxLength(100);

        // this is EF core feature called table spliting or table sharing
        builder.OwnsOne(menu => menu.AverageRating);

        builder.Property(menu => menu.HostId)
        .HasConversion(
            id => id.Value,
            value => HostId.Create(value)
        );
    }
}