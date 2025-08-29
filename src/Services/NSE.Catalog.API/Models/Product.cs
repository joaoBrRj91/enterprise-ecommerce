using NSE.Shared.DomainObjects;

namespace NSE.Catalog.API.Models;

public class Product : Entity
{
    public string Name { get; set; }
    public string Descricao { get; set; }
    public bool IsACtive { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateDate { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }

}
