using System;
using Project.SQL;
namespace Project.ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var dependencies = new Project.Library.Dependencies();

            var context = dependencies.CreateDbContext();

            Repository repository = new Repository(context);

            MainMenu(repository);
        }

        public static void MainMenu(Repository repository)
        {
            
            while (true)
            {
                Console.WriteLine("c:  Customer Menu.");
                Console.WriteLine("o:  Order Menu.");
                Console.WriteLine("p:  Product Menu.");
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
                else if (userinput == "q")
                {
                    break;
                }
            }
        }
    }
}
