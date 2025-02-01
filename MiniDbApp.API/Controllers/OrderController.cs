using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;
using MiniDbApp.Lib.Constants;
using MiniDbApp.Models.Order;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class OrderController : Controller
{
    private readonly OrderDbService _orderDb;

    public OrderController(OrderDbService orderDb)
    {
        _orderDb = orderDb;
    }

    [HttpGet(Urls.Api.V1.Order.BY_ID)]
    public Order? GetOrderById(string id)
    {
        if (Guid.TryParse(id, out Guid orderId))
        {
            return _orderDb.ById(orderId);
        }

        return null;
    }

    [HttpGet(Urls.Api.V1.Order.LIST)]
    public List<Order> List(int index = 0, int count = Setup.Api.DEFAULT_COUNT)
    {
        return _orderDb.Orders(index, count);
    }

    [HttpGet(Urls.Api.V1.Order.CUSTOMER_LIST)]
    public List<Order> CustomerOrderList(string customerId, int index = 0, int count = Setup.Api.DEFAULT_COUNT)
    {
        return _orderDb.Orders(customerId, index, count);
    }

    [HttpPost(Urls.Api.V1.Order.CREATE)]
    public Order? Create(string customerId)
    {
        return _orderDb.Create(customerId);
    }

    [HttpGet(Urls.Api.V1.Order.ADD_ITEM)]
    [HttpGet(Urls.Api.V1.Order.UPDATE_ITEM)]
    public IActionResult AddOrEditItem(Guid orderId, Guid productId, int quantity) // TODO: TryParse Guid
    {
        _orderDb.AddOrEditItem(orderId, productId, quantity);

        return Ok();
    }

    [HttpGet(Urls.Api.V1.Order.REMOVE_ITEM)]
    public IActionResult RemoveItem(Guid orderId, Guid productId) // TODO: TryParse Guid
    {
        _orderDb.AddOrEditItem(orderId, productId, 0);

        return Ok();
    }

    [HttpGet(Urls.Api.V1.Order.ITEM_LIST)]
    public List<OrderProduct>? Items(string id)
    {
        if (Guid.TryParse(id, out Guid orderId))
        {
            return _orderDb.Items(orderId);
        }

        return null; 
    }
}