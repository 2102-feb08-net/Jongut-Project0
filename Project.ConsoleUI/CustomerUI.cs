using Project.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.ConsoleUI
{
    public static class CustomerUI
    {
        public static void DisplayOptions(Repository repository)
        {

            while (true)
            {
                Console.WriteLine("c: To Create A New Customer");
                Console.WriteLine("s: To Search A Customer By Name");
                Console.WriteLine("h: Display Customer history");
                Console.WriteLine("q: To Return Back to the Main Menu");
                Console.WriteLine();

                string userinput = Console.ReadLine().ToLower();

                if (userinput == "c")
                {
                    Console.WriteLine("Please Enter The Customers First Name\n");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Please Enter The Customers Last Name\n");
                    string lastname = Console.ReadLine();
                    try
                    {
                        Project.Library.Customer customer = new Project.Library.Customer(firstname, lastname, 1);
                        repository.AddCustomer(customer);
                            Console.WriteLine("Successfully added Customer");
                            Console.WriteLine("Remember to save to lock in changes.");

                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine("Could not Create Customer");
                        Console.WriteLine(exception.Message);
                    }

                }
                else if (userinput == "s")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter a First or Last Name you would like to search for.\n");

                    Console.WriteLine("First Name:");
                    string searchfirstname = Console.ReadLine();

                    Console.WriteLine("Last Name:");
                    string searchlastname = Console.ReadLine();

                    var customers = repository.SearchCustomer(searchfirstname, searchlastname);                   
                    Console.WriteLine($"ID:{customers.CustomerID} {customers.FirstName},{customers.LastName}");
                    
                }

                else if (userinput == "h")
                {
                   
                    Console.WriteLine();
                    Console.WriteLine("Please enter the id of the customer whose order history you'd like to view.\n");
                    int customerid;

                    while (true)
                    {
                        string customeridstring = Console.ReadLine();

                        if (int.TryParse(customeridstring,out customerid))
                        {
                            break;
                        }

                        Console.WriteLine("Value must be an integer");
                    }

                    var orders = repository.GetOrderByCustomerId(customerid);

                    var customer = repository.FindCustomerID(customerid);

                    int count = orders.Count;

                    Console.WriteLine($"\nWe found {count} results for you from {customer.FirstName}, {customer.LastName}\n");

                    if(count > 0)
                    {
                        foreach (var order in orders)
                        {
                            Console.WriteLine($"Order Id:{order.OrderID} -- Customer with Id:{order.CustomerID} took an order from store with Id:{order.StoreID} at {order.OrderTime}\n");
                        }
                    };
                }

                else if (userinput == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("Returning to Main Menu\n");
                    break;
                }




            }
        }


    }
}
