using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Models;
using NSE.Shared.Data;

namespace NSE.Catalog.API.Data;

public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}

