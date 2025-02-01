using Mapster;
using MiniDbApp.Database.Database;
using MiniDbApp.Models.Product;

namespace MiniDbApp.Database.Services;

public class ProductDbService
{
    private readonly ShopDbContext _database;

    public ProductDbService(ShopDbContext database)
    {
        _database = database;
    }

    public Product? ById(Guid id)
    {
        return _database.Products.FirstOrDefault(x => x.ProductId == id).Adapt<Product?>();
    }

    public List<Product> Products(int index, int count)
    {
        return _database.Products.Skip(index).Take(count).ProjectToType<Product>().ToList();
    }

    public void CreateOrUpdate(Product product)
    {
        var dbProduct = _database.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

        if (dbProduct == null)
        {
            _database.Products.Add(product.Adapt<Database.Tables.Product>());
        }
        else
        {
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Tax = product.Tax;
        }

        _database.SaveChanges();
    }

    public int Count()
    {
        return _database.Products.Count();
    }
}