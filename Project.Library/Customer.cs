using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Project.Library
{
    public class Customer

    {
        public String FirstName {get; private set;}
        public String LastName {get; private set;}
        public int CustomerID { get; private set; }
        
        public Customer(string firstName, string lastName, int id = 0)
        {
            string FirstNameValid = ValidCustomer(firstName);
            string LastNameValid =ValidCustomer(lastName);
            FirstName = FirstNameValid;
            LastName = FirstNameValid;
            this.CustomerID = id;
        }
        public string ValidCustomer(string name)
        {
           
           
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("There are no letters");
            }

            // Seperates string into a character array to check and make sure all characters are letters,
            // Throws an ArgumentException error if it finds a non letter

            char[] nameletters = name.ToCharArray();

         
            for (int i = 0; i < nameletters.Length; i++)
            {
                if (!char.IsLetter(nameletters[i]))
                {
                    throw new ArgumentException("All characters must be a letter");
                }

            }

            // Returns a formatted Name

            string FinalName = FormatName(name);

            return FinalName;
        }
        public static string FormatName(string Name)
        {
          
            char[] nameletters = Name.ToCharArray();

            //Capitalizes the first letter of the word, while lowercasing the rest.
            // !!Important!! Throws ArguementException Error if character is not a letter.

            for (int i = 0; i < nameletters.Length; i++)
            {

                if (i == 0)
                {
                    nameletters[0] = char.ToUpper(nameletters[0]);
                }
                else
                {
                    nameletters[i] = char.ToLower(nameletters[i]);
                }
            }

            return new string(nameletters);
        }
    }
}
