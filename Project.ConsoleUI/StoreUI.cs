using Project.SQL;
using System;
namespace Project.ConsoleUI
{
    /// <summary>
    /// Allows users to Add a store location and view a store locations Order History
    /// </summary>
    public static class StoreUI
    {
        public static void DisplayOptions(IProject0Repository repository)
        {

            while (true)
            {
                Console.WriteLine("You are now viewing the Store Location Management Menu");
                Console.WriteLine();
                Console.WriteLine("h: View a Store Location's Order History");
                Console.WriteLine("c: Create a Store Location");
                Console.WriteLine("q: To Return Back to the Main Menu");

                Console.WriteLine();

                string userinput = Console.ReadLine();

                if (userinput == "c")
                {

                    Console.WriteLine("Please Enter The Store Locations City\n");
                    string city = Console.ReadLine();
                    Console.WriteLine("Please Enter Its State\n");
                    string state = Console.ReadLine();
                    Console.WriteLine("Please Enter The Address\n");
                    string address = Console.ReadLine();
                    Console.WriteLine("Please Enter The Locations Phone Number\n");
                    string phoneNumber = Console.ReadLine();

 
                    try
                    {
                        Project.Library.StoreLocation storeLocation = new Project.Library.StoreLocation(city, state, address, phoneNumber);
                        
                        if (repository.AddStoreLocation(storeLocation))
                        {
                            Console.WriteLine("Successfully added Store Location");
                            Console.WriteLine("Remember to save to lock in changes.");
                        }   
           

                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine("Could not Create Store Location");
                        Console.WriteLine(exception.Message);
                    }

                }
                else if (userinput == "h")
                {

                    Console.WriteLine();
                    Console.WriteLine("Please enter the id of the store whose order history you'd like to view.\n");
                    int storeid;

                    while (true)
                    {
                        string storeidstring = Console.ReadLine();

                        if (int.TryParse(storeidstring, out storeid))
                        {
                            break;
                        }

                        Console.WriteLine("Value must be an integer");
                    }

                    var orders = repository.GetOrderByStoreId(storeid);


                    int count = orders.Count;

                    Console.WriteLine($"\nWe found {count} results for this store\n");

                    if (count > 0)
                    {
                        foreach (var order in orders)
                        {
                            Console.WriteLine($"Order Id:{order.OrderID} Customer with Id:{order.CustomerID} took an order here at {order.OrderTime}\n");
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
