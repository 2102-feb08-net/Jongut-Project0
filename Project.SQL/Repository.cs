using System;
using System.Collections.Generic;
using System.Linq;
using Project.SQL;

public class Repository : IProject0Repository
{
    private readonly Project0SQLContext _DBcontext;         

    public Repository(Project0SQLContext context)
    {
        _DBcontext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool AddCustomer(Project.Library.Customer customer)
    {
        Project.SQL.Customer Newcustomer = new Project.SQL.Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            CustomerId = customer.CustomerID
        };       
        _DBcontext.Add(Newcustomer);

        return true;
    }
    public Project.Library.Customer SearchCustomer(string firstname)
    {
        var result = _DBcontext.Customers.Where(x => x.FirstName == firstname).FirstOrDefault();

            Project.Library.Customer customer = new Project.Library.Customer(result.FirstName, result.LastName, result.CustomerId);

            return customer;
    }

    public bool AddOrder(Project.Library.Order Order)
    {
        Project.SQL.Order order = new Project.SQL.Order() 
        { 
            CustomerId = Order.CustomerID,
            StoreLocationId = Order.StoreID,
            OrderTimes = Order.OrderTime
        };

        _DBcontext.Add(order);

        return true;
    }

    public bool AddProduct(Product Product)
    {
        Product product = new Product() 
        { 
            ProductId = Product.ProductId, 
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
    public List<Project.Library.Order> GetOrderByStoreId(int storeid)
        {
            List<Project.Library.Order> orders = new List<Project.Library.Order>();

            var results = _DBcontext.Orders.Where(x => x.StoreLocationId == storeid);

            foreach (var result in results)
            {
                orders.Add(new Project.Library.Order(result.CustomerId,result.StoreLocationId,result.OrderTimes, result.Id));
            }

            return orders;

        }
    public List<Project.Library.Order> GetOrderByCustomerId(int customerid)
        {
            List<Project.Library.Order> orders = new List<Project.Library.Order>();

            var results = _DBcontext.Orders.Where(x => x.CustomerId == customerid);

            foreach (var result in results)
            {
                orders.Add(new Project.Library.Order(result.CustomerId, result.StoreLocationId, result.OrderTimes, result.Id));
            }

            return orders;

        }   
        public Project.Library.Customer FindCustomerID(int customerid)
        {

            var result = _DBcontext.Customers.Where(x => x.CustomerId == customerid).FirstOrDefault();

            Project.Library.Customer customer = new Project.Library.Customer(result.FirstName, result.LastName, result.CustomerId);

            return customer;
        }

        public bool AddStoreLocation(Project.Library.StoreLocation BStoreLocation)
        {

            // ID left at default 0
            StoreLocation storeLocation = new StoreLocation() 
            { 
                Id = BStoreLocation.Id, 
                Address = BStoreLocation.Address, 
                City = BStoreLocation.City, 
                State = BStoreLocation.State,
                PhoneNumber = BStoreLocation.PhoneNumber
            };

            _DBcontext.Add(storeLocation);

            return true;
        }  

    public bool SaveChanges()
    {
        _DBcontext.SaveChanges();
        return true;
    }
}