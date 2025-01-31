using Microsoft.EntityFrameworkCore;

namespace MiniDbApp.Database.Database.Tables;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class ProductInOrder
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; } 

    public Product Product { get; set; }
    public Order Order { get; set; }
}