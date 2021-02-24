using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Project.Library
{
    public class Customer

    {
        public String FirstName {get; private set;}
        public String LastName {get; private set;}
        public int CustomerID = 0;
        
        public Customer(string firstName, string lastName, int id)
        {
            string FirstNameValid = firstName;

            string LastNameValid =lastName;

            FirstName = FirstNameValid;

            LastName = FirstNameValid;

            CustomerID = id;
        }
        public string ValidCustomer(string name)
        {
            Console.WriteLine("Enter the name of the customer: ");
            name = Console.ReadLine();
            if (!Regex.IsMatch(FirstName, @"^[\p{L} \.\-]+$"))
            {
                throw new ArgumentException("Name can't be empty! Input your first name again: ");
            }
            else if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("There are no letters");
            }
            char[] letters = name.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (!char.IsLetter(letters[i]))
                {
                    throw new ArgumentException("All characters must be a letter");
                }
                if (i == 0)
                {
                    letters[0] = char.ToUpper(letters[0]);
                }
                else
                {
                    letters[i] = char.ToLower(letters[i]);
                }

            }           
            return name;
        }
    }
}
