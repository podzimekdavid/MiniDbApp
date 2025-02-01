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
                // Products

                var p4 = new Product()
                {
                    ProductId = Guid.Parse("B0E80154-3E43-4CD2-B3CE-E7C321191294"),
                    Name = "AlzaPower LED 9-60W, E27, 6500K, set 3ks",
                    Price = 139m,
                    Tax = 21,
                };
                products.CreateOrUpdate(p4);

                var p3 = new Product()
                {
                    ProductId = Guid.Parse("5b8bf769-4286-4934-b99f-782b737372b0"),
                    Name = "Brother TN-2421 černý",
                    Price = 1929m,
                    Tax = 21,
                };
                products.CreateOrUpdate(p3);

                var p2 = new Product()
                {
                    ProductId = Guid.Parse("60C00BB9-3D40-4240-81DF-E8895E16466E"),
                    Name = "LEGO Botanicals 10368 Chryzantéma",
                    Price = 530m,
                    Tax = 21,
                };
                products.CreateOrUpdate(p2);

                var p1 = new Product()
                {
                    ProductId = Guid.Parse("0030CFA7-BA33-430E-BE62-33D0EB617D58"),
                    Name = "LEGO City 60367 Osobní letadlo",
                    Price = 2039m,
                    Tax = 21,
                };
                products.CreateOrUpdate(p1);

                // Customers
                customers.CreateOrUpdate(new()
                {
                    Email = "pavel@seznam.cz",
                    Name = "Pavel",
                    Surname = "Novotny"
                });

                customers.CreateOrUpdate(new()
                {
                    Email = "jan@email.cz",
                    Name = "Jan",
                    Surname = "Kozak"
                });
                customers.CreateOrUpdate(new()
                {
                    Email = "jirka@gmail.com",
                    Name = "Jiri",
                    Surname = "Novak"
                });

                // Orders
                var order1 = orders.Create("pavel@seznam.cz");
                orders.AddOrEditItem(order1.OrderId, p1.ProductId, 2);
                
                var order2 = orders.Create("pavel@seznam.cz");
                orders.AddOrEditItem(order2.OrderId, p2.ProductId, 1);
                orders.AddOrEditItem(order2.OrderId, p3.ProductId, 1);                
                
                var order3 = orders.Create("jirka@gmail.com");
                orders.AddOrEditItem(order3.OrderId, p4.ProductId, 6);
                orders.AddOrEditItem(order3.OrderId, p3.ProductId, 1);
                orders.AddOrEditItem(order2.OrderId, p1.ProductId, 1);
            }
        }
    }
}