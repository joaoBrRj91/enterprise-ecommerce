using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Models;
using NSE.Shared.Data;

namespace NSE.Catalog.API.Data;

public class ProductRepository(CatalogContext catalogContext) : IProductRepository
{
    public IUnitOfWork UnitOfWork => catalogContext;

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await catalogContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await catalogContext.Products.FindAsync(id);
    }

    public void Add(Product product)
    {
        catalogContext.Products.Add(product);
    }

    public void Update(Product product)
    {
        catalogContext.Products.Update(product);
    }

    public void Dispose()
    {
        catalogContext?.Dispose();
    }

}
