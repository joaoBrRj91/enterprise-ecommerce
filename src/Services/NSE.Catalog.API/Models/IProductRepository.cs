using NSE.Shared.Data;

namespace NSE.Catalog.API.Models;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);

    void Add(Product product);
    void Update(Product product);
}
