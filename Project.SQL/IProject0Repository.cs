using System;
using System.Collections.Generic;
using Project.Library;
namespace Project.SQL
{
    public interface IProject0Repository
    {
        /// <summary>
        /// Get all customers with optional name search string and deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        Library.Customer SearchCustomer(string search = null);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        bool AddCustomer(Project.Library.Customer customer);



        /// <summary>
        /// Get all products with optional name search string and deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        List<Project.Library.Order> GetOrderByCustomerId(int customerid);

        Library.Customer FindCustomerID (int customerid);



        /// <summary>
        /// Get all orders with option customerId search and deferred execution.
        /// </summary>
        List<Project.Library.Order> GetOrderByStoreId(int storeid);

        /// <summary>
        /// Add new orders to store locations for customers.
        /// </summary>
        bool AddOrder(Project.Library.Order Order);

        bool AddStoreLocation(Project.Library.StoreLocation BStoreLocation);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        bool SaveChanges();
    }
}
