using Mapster;
using MiniDbApp.Database.Adapters;
using MiniDbApp.Database.Database;
using MiniDbApp.Models.Order;

namespace MiniDbApp.Database.Services;

public class OrderDbService
{
    private readonly ShopDbContext _database;

    public OrderDbService(ShopDbContext database)
    {
        _database = database;
    }

    public Order? ById(Guid id)
    {
        return _database.Orders.FirstOrDefault(x => x.OrderId == id).Adapt<Order?>();
    }

    public List<Order> Orders(int index, int count)
    {
        return _database.Orders.Skip(index).Take(count).ProjectToType<Order>().ToList();
    }

    public List<Order> Orders(string customerId, int index, int count)
    {
        return _database.Orders.Where(x => x.CustomerId == customerId).Skip(index).Take(count).ProjectToType<Order>()
            .ToList();
    }

    public Order? Create(string customerId)
    {
        if (!_database.Customers.Any(x => x.Email == customerId))
            return null;

        Order order = new()
        {
            OrderId = Guid.NewGuid(),
            Created = DateTime.Now,
            CustomerId = customerId
        };

        _database.Orders.Add(order.Adapt<Database.Tables.Order>());

        _database.SaveChanges();

        return order;
    }

    public void AddOrEditItem(Guid orderId, Guid productId, int quantity)
    {
        var orderItem = _database.ProductInOrders
            .FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);

        if (orderItem == null)
        {
            if (!(_database.Orders.Any(x => x.OrderId == orderId) &&
                  _database.Products.Any(x => x.ProductId == productId)))
                return;

            _database.ProductInOrders.Add(new()
            {
                ProductId = productId,
                OrderId = orderId,
                Quantity = quantity
            });
        }
        else
        {
            if (quantity <= 0)
                _database.ProductInOrders.Remove(orderItem);
            else
                orderItem.Quantity = quantity;
        }

        _database.SaveChanges();
    }

    public List<OrderProduct> Items(Guid orderId)
    {
        return _database.ProductInOrders.Where(x => x.OrderId == orderId)
            .ProjectToType<OrderProduct>(ProductInOrderAdapter.Config).ToList();
    }
}