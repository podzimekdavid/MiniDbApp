using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class OrderController : Controller
{
    private readonly OrderDbService _orderDb;

    public OrderController(OrderDbService orderDb)
    {
        _orderDb = orderDb;
    }
}