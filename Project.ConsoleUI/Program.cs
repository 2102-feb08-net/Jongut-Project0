using System;
using Project.SQL;
namespace Project.ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var dependencies = new Dependencies();
            
            IProject0Repository repository = dependencies.CreateRepository();
            
            MainMenu(repository);
        }

        public static void MainMenu(IProject0Repository repository)
        {            
            while (true)
            {
                Console.WriteLine("c:  Customer Menu.");
                Console.WriteLine("o:  Order Menu.");
                Console.WriteLine("l:  Store Menu.");
                Console.WriteLine("p:  Product Menu.");
                Console.WriteLine("s:  Save Data.");
                Console.WriteLine("q: Quit Program");
                Console.WriteLine();
                string userinput = Console.ReadLine();

                Console.WriteLine();

                if (userinput == "c")
                {
                    CustomerUI.DisplayOptions(repository);
                }
                else if (userinput == "p")
                {
                    ProductUI.DisplayOptions(repository);
                }
                else if (userinput == "o")
                {
                    OrderUI.DisplayOptions(repository);
                }
                else if(userinput == "l")
                {
                    StoreUI.DisplayOptions(repository);
                }
                else if (userinput == "s")
                {
                    if (repository.SaveChanges())
                    {
                        Console.WriteLine("--Successfully Saved Data to Database!\n");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                else if (userinput == "q")
                {
                    break;
                }
            }
        }
    }
}
