using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;
using Project.Library;

public class Repository :IRepository
{
    private readonly ProjectSQLContext _DBcontext;         
    private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

    public Repository(ProjectSQLContext context)
    {
        _DBcontext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool AddCustomer(Customer customer)
    {
        Customer customer = new Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            CustomerID = customer.CustomerID
        };

        var entity = new Customer
        _DBcontext.Add(customer);

        return true;
    }

    public void DeleteCustomer(int CustomerId)
    {
        s_logger.Info($"Deleting Customer with ID {CustomerId}");
        Restaurant entity = _dbContext.Restaurant.Find(CustomerId);
        _dbContext.Remove(entity);
    }

    public Library.Customer SearchCustomer(int customerid)
    {
        var result = _DBcontext.Customers.Where(x => x.Id == customerid).FirstOrDefault();
        Library.Customer customer = new Library.Customer(result.FirstName, result.LastName, result.Id);
        return customer;
    }

    public bool AddOrder(Order Order)
    {
        Order order = new Order() 
        { 
            CustomerId = Order.CustomerId,
            StoreLocationId = Order.StoreId,
            OrderTime = Order.OrderTime 
        
        };

        _DBcontext.Add(order);

        return true;
    }

     public List<Library.Order> SearchCustomer(int customerid)
    {
        List<Library.Order> orders = new List<Library.Order>();

        var results = _DBcontext.Orders.Where(x => x.CustomerId == customerid);

        foreach (var result in results)
        {
            orders.Add(new Library.Order(result.CustomerId,
            result.StoreLocationId,
            result.OrderTime.Value,
            result.Id)
            );
        }

        return orders;

    }

    public bool AddProduct(Product Product)
    {
        Product product = new Product() 
        { 
            Id = Product.Id, 
            ProductName = Product.ProductName, 
            Price = Product.Price 
        };

        _DBcontext.Add(product);

        return true;
    }

    public bool AddStoreLocation(StoreLocation StoreLocation)
    {

        // ID left at default 0
        StoreLocation storeLocation = new StoreLocation()
        {
            Id = StoreLocation.Id,
            Address = StoreLocation.Address,
        };

        _DBcontext.Add(storeLocation);

        return true;
    }    

    public List<Library.Order> FindOrderStore(int storeid)
    {
        List<Library.Order> orders = new List<Library.Order>();

        var results = _DBcontext.Orders.Where(x => x.StoreLocationId == storeid);

        foreach (var result in results)
        {
            orders.Add(new Library.Order(result.CustomerId, 
            result.StoreLocationId, 
            result.OrderTime.Value, 
            result.Id));
        }

        return orders;

    }

    public bool SaveChanges()
    {
        s_logger.Info("Saving changes to the database");
        _DBcontext.SaveChanges();
        return true;
    }
}