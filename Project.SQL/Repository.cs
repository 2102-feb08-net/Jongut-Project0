using System;
using System.Collections.Generic;
using System.Linq;
using Project.SQL;
using Project.Library;

public class Repository
{
    private readonly ProjectSQLContext _DBcontext;         

    public Repository(ProjectSQLContext context)
    {
        _DBcontext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool AddCustomer(Project.Library.Customer customer)
    {
        Project.SQL.Customer Newcustomer = new Project.SQL.Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            CustomerID = customer.CustomerID
        };       
        _DBcontext.Add(Newcustomer);

        return true;
    }
    public Project.Library.Customer SearchCustomer(string firstname, string lastname)
    {
        var result = _DBcontext.Customer.Where(x => x.FirstName == firstname).FirstOrDefault();

            Project.Library.Customer customer = new Project.Library.Customer(result.FirstName, result.LastName, result.CustomerID);

            return customer;
    }

    public bool AddOrder(Project.Library.Order BOrder)
    {
        Project.SQL.Order order = new Project.SQL.Order() 
        { 
            CustomerID = BOrder.CustomerID,
            StoreID = BOrder.StoreID,
            OrderTime = BOrder.OrderTime 
        
        };

        _DBcontext.Add(order);

        return true;
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
    public List<Project.Library.Order> GetOrderByStoreId(int storeid)
        {
            List<Project.Library.Order> orders = new List<Project.Library.Order>();

            var results = _DBcontext.Order.Where(x => x.StoreID == storeid);

            foreach (var result in results)
            {
                orders.Add(new Project.Library.Order(result.CustomerID,result.StoreID,result.OrderTime.Value,result.Id));
            }

            return orders;

        }
    public List<Project.Library.Order> GetOrderByCustomerId(int customerid)
        {
            List<Project.Library.Order> orders = new List<Project.Library.Order>();

            var results = _DBcontext.Order.Where(x => x.CustomerID == customerid);

            foreach (var result in results)
            {
                orders.Add(new Project.Library.Order(result.CustomerID, result.StoreID, result.OrderTime.Value, result.Id));
            }

            return orders;

        } 
        public Project.Library.Customer FindCustomerID(int customerid)
        {

            var result = _DBcontext.Customer.Where(x => x.CustomerID == customerid).FirstOrDefault();

            Project.Library.Customer customer = new Project.Library.Customer(result.FirstName, result.LastName, result.CustomerID);

            return customer;
        }  

    public bool SaveChanges()
    {
        _DBcontext.SaveChanges();
        return true;
    }
}