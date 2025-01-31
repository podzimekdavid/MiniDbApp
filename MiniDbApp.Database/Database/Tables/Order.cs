namespace MiniDbApp.Database.Database.Tables;

public class Order
{
    public Guid OrderId { get; set; }
    public string CustomerId { get; set; }
    
    public DateTime Created { get; set; } 
    
    public IEnumerable<ProductInOrder> Products { get; set; }
    public Customer Customer { get; set; }
 }