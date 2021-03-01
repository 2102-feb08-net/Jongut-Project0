using System;
using Project.SQL;
namespace Project.ConsoleUI
{
    public static class OrderUI
    {
        public static void DisplayOptions(IProject0Repository repository)
        {

            while (true)
            {
                Console.WriteLine("c: Create A New Order");
                Console.WriteLine("q: To Return Back to the Main Menu");

                Console.WriteLine();

                string userinput = Console.ReadLine();


                if (userinput == "c")
                {


                    int customerid;

                    while (true)
                    {
                        Console.WriteLine("Please Enter The Customer ID\n");
                        string customeridstring = Console.ReadLine();

                        if (int.TryParse(customeridstring, out customerid))
                        {
                            break;
                        }
                        else if (customeridstring == "q")
                        {
                            break;
                        }
                    }

                    int storeid;

                    while (true)
                    {
                        Console.WriteLine("Please Enter The Store ID\n");
                        string storeids = Console.ReadLine();

                        if (int.TryParse(storeids, out storeid))
                        {
                            break;
                        }
                        else if (storeids == "q")
                        {
                            break;
                        }
                    }
                    DateTime OrderTime = DateTime.Now;
                    try
                    {                        
                        Project.Library.Order order = new Project.Library.Order(customerid, storeid, OrderTime);
                        repository.AddOrder(order);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine("Could not Create Order");
                        Console.WriteLine(exception.Message);
                    }

                }

                else if (userinput == "q")
                {
                    Console.WriteLine("Returning to Main Menu\n");
                    break;
                }
            }
        }
    }
}
