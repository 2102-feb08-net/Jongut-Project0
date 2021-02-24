using Project_Library;
using Project_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jonathan_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            Customer c = new Customer();
            Store s = new Store();
            Order o = new Order();
            Console.Clear();
            Console.WriteLine("Welcome! What would you like?");
            MainMenu(c, s, o);
        }

        static public void MainMenu(Customer c, Store s, Order o)
        {
            while (true) 
            { 
            Console.WriteLine("1. Add a Customer: ");
            Console.WriteLine("2. Search Customer by ID: ");
            Console.WriteLine("3. Add an Item to the inventory: ");
            Console.WriteLine("4. Print the Inventory: ");
            Console.WriteLine("5. Add a store: ");
            Console.WriteLine("6. Display all stores: ");
            Console.WriteLine("7. Find store by ID: ");
            Console.WriteLine("9. Add an Order: ");
            int choice = int.Parse(Console.ReadLine());
                while (choice != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            c.AddCustomer();
                            break;
                        case 2:
                            c.SearchCustomer();
                            break;
                        case 3:
                            s.AddItemToInventory();
                            break;
                        case 4:
                            s.printInventory();
                            break;
                        case 5:
                            s.AddStores();
                            break;
                        case 6:
                            s.displayStores();
                            break;
                        case 7:
                            s.findStore();
                            break;
                        case 8:
                            o.AddOrder();
                            break;
                        case 9:
                            o.RemoveOrder();
                            break;
                        default:
                            Console.WriteLine("Wrong Input");
                            break;
                    }
                }
            }
        }
    }
}
