using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;
using MiniDbApp.Lib.Constants;
using MiniDbApp.Models.Customer;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class CustomerController : Controller
{
    private readonly CustomerDbService _customerDb;

    public CustomerController(CustomerDbService customerDb)
    {
        _customerDb = customerDb;
    }

    [HttpGet(Urls.Api.V1.Customer.BY_ID)]
    public Customer? GetCustomerById(string email)
    {
        return _customerDb.ById(email);
    }

    [HttpGet(Urls.Api.V1.Customer.LIST)]
    public List<Customer> List(int index = 0, int count = 10)
    {
        return _customerDb.Customers(index, count);
    }

    [HttpPost(Urls.Api.V1.Customer.CREATE)]
    [HttpPost(Urls.Api.V1.Customer.UPDATE)]
    public IActionResult CreateOrUpdate([FromBody] Customer? customer)
    {
        if (customer == null)
            return BadRequest("Missing customer data");

        try
        {
            _customerDb.CreateOrUpdate(customer);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); // TODO: remove, just for dev
        }
    }
}