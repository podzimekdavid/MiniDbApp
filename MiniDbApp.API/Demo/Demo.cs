using MiniDbApp.Database.Database.Tables;
using MiniDbApp.Database.Services;
using Product = MiniDbApp.Models.Product.Product;

namespace MiniDbApp.API.DemoData;

public static class Demo
{
    public static void SeedDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var customers = scope.ServiceProvider.GetRequiredService<CustomerDbService>();
            var products = scope.ServiceProvider.GetRequiredService<ProductDbService>();
            var orders = scope.ServiceProvider.GetRequiredService<OrderDbService>();

            if (products.Count() == 0)
            {
                
                products.CreateOrUpdate(new ()
                {
                    ProductId = Guid.Parse("B0E80154-3E43-4CD2-B3CE-E7C321191294"),
                    Name = "AlzaPower LED 9-60W, E27, 6500K, set 3ks",
                    Price = 139m,
                    Tax = 21,
                });
                
            }
        }
    }
}