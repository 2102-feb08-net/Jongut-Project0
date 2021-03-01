using Project.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.ConsoleUI
{
    public static class ProductUI
    {
        public static void DisplayOptions(IProject0Repository repository)
        {

            while (true)
            {
                Console.WriteLine("You are now viewing the Product Management Menu.");
                Console.WriteLine();
                Console.WriteLine("c: To Create A New Product");
                Console.WriteLine("q: To Return Back to the Main Menu");
                Console.WriteLine();

                string userinput = Console.ReadLine().ToLower();

                if (userinput == "c")
                {

                    Console.WriteLine("Please Enter The Products Name\n");
                    string productname = Console.ReadLine();
                    decimal price;

                    while (true)
                    {

                        Console.WriteLine("Please Enter The Products Price\n");
                        string pricestring = Console.ReadLine();

                        if (decimal.TryParse(pricestring, out price))
                        {
                            break;
                        }                 
                    }
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
