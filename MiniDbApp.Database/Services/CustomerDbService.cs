using Mapster;
using MiniDbApp.Database.Database;
using MiniDbApp.Models.Customer;


namespace MiniDbApp.Database.Services;

public class CustomerDbService
{
    private readonly ShopDbContext _database;

    public CustomerDbService(ShopDbContext database)
    {
        _database = database;
    }

    public Customer? ById(string email)
    {
        return _database.Customers.FirstOrDefault(x => x.Email == email).Adapt<Customer?>();
    }

    public List<Customer> Customers(int index, int count)
    {
        return _database.Customers.Skip(index).Take(count).ProjectToType<Customer>().ToList();
    }

    public void CreateOrUpdate(Customer customer)
    {
        var dbCustomer = _database.Customers.FirstOrDefault(x => x.Email == customer.Email);

        if (dbCustomer == null)
        {
            _database.Customers.Add(customer.Adapt<Database.Tables.Customer>());
        }
        else
        {
            dbCustomer.Name = customer.Name;
            dbCustomer.Surname = customer.Surname;
        }

        _database.SaveChanges();
    }
}