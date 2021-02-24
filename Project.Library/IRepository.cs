using System;

public interface IRepository
{
    Customer AddCustomer(int id);
    IEnumerable<Customer> GetCustomers(string search = null);
    void Add(Customer c);
    void Delete(Customer CustomerID);
    void Save();
}   