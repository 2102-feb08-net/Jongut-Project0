using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Product
    {
        public int Id { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public Product(string productName, decimal price, int id = 0)
        {

            ValidateName(productName);
            
            ValidatePrice(price);

            Price = price;

            ProductName = productName;

            Id = id;
        }

        private void ValidatePrice(decimal price)
        {
            if (price<0)
            {
                throw new ArgumentException("Price must be greater than 0");
            }
        }

        private void ValidateId(int productNumber)
        {
            if (productNumber < 0)
            {
                throw new ArgumentException("Product number must be positve");
            }

        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be empty");
            }



            if(name.Length > 100)
            {
                throw new ArgumentException("This is a name, not a description");
            }
        }
    }
}
