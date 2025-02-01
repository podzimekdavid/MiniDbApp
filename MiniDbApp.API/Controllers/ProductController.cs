using Microsoft.AspNetCore.Mvc;
using MiniDbApp.API.Filters;
using MiniDbApp.Database.Services;
using MiniDbApp.Lib.Constants;
using MiniDbApp.Models.Product;

namespace MiniDbApp.API.Controllers;

[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ProductController : Controller
{
    private readonly ProductDbService _productDb;

    public ProductController(ProductDbService productDb)
    {
        _productDb = productDb;
    }

    [HttpGet(Urls.Api.V1.Product.BY_ID)]
    public Product? GetProductById(string id)
    {
        if (Guid.TryParse(id,out Guid productId))
        {
            return _productDb.ById(productId);
        }

        return null;

    }

    [HttpGet(Urls.Api.V1.Product.LIST)]
    public List<Product> List(int index = 0, int count = Setup.Api.DEFAULT_COUNT)
    {
        return _productDb.Products(index, count);
    }

    [HttpPost(Urls.Api.V1.Product.CREATE)]
    [HttpPost(Urls.Api.V1.Product.UPDATE)]
    public IActionResult CreateOrUpdate([FromBody] Product? product)
    {
        if (product == null)
            return BadRequest("Missing product data");

        try
        {
            _productDb.CreateOrUpdate(product);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); // TODO: remove, just for dev
        }
    }
}