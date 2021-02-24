using System;
using System.Collections.Generic;

namespace Project_Library
{
    public class Customer

    {
        Dictionary<int, string> CustomerList = new Dictionary<int, string>();
        private String FirstName;
        private String LastName;
        public int CustomerID = 0;

        public void AddCustomer()
        {
            Console.WriteLine("Enter the first name of the customer: ");
            FirstName = Console.ReadLine();
            if (!Regex.IsMatch(FirstName, "^[\p{L} \.\-]+$"))
            {
                throw new ArgumentException("Name can't be empty! Input your first name again: ");
            }
            else
            {                
                string resultF = FirstName.Trim();
            }
            Console.WriteLine("Enter the last name of the customer: ");
            LastName = Console.ReadLine();
            if (!Regex.IsMatch(LastName, "^[\p{L} \.\-]+$"))
            {
                throw new ArgumentException("Name can't be empty! Input your first name again: ");
            }
            else
            {                
                string resultL = LastName.Trim();
            }
            CustomerID += 1;
            Console.ReadLine();
        }

        public void SearchCustomer()
        {
            Console.WriteLine("Enter your Customer ID: ");
            int res = int.Parse(Console.ReadLine());
            if (!CustomerList.ContainsKey(res))
            {
                Console.WriteLine("Invalid ID");
                attempt++;
                if (attempt == 5)
                    return;
                SearchCustomer();
            }
        }
    }
}
