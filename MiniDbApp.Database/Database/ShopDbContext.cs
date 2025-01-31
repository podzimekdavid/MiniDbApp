using Microsoft.EntityFrameworkCore;
using MiniDbApp.Database.Database.Tables;

namespace MiniDbApp.Database.Database;

public class ShopDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInOrder> ProductInOrders { get; set; }
    
    public ShopDbContext(DbContextOptions<ShopDbContext> contextOptions) : base(contextOptions)
    {

    }
}