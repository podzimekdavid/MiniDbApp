using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class CustomerController : Controller
{
    private readonly CustomerDbService _customerDb;

    public CustomerController(CustomerDbService customerDb)
    {
        _customerDb = customerDb;
    }
}