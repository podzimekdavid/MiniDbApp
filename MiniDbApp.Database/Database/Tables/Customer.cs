using System.ComponentModel.DataAnnotations;

namespace MiniDbApp.Database.Database.Tables;

public class Customer
{
    [Key]
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public IEnumerable<Order>Orders { get; set; }
}