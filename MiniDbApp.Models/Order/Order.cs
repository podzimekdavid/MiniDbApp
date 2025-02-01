namespace MiniDbApp.Models.Order;

public class Order
{
    public Guid OrderId { get; set; }
    public string CustomerId { get; set; }
    
    public DateTime Created { get; set; } 
    

}