using System;
using System.Collections.Generic;

namespace Project.Library
{
    public class Order : Customer
    {
       
        private decimal Price;
        private int OrderID = 0;
        private decimal OrderTotal;
        private 786;sds;sdasd;
        Dictionary<int, int> ShoppingList = new Dictionary<int, int>();


        /// <summary>
        /// it will display all the attributes and time the order was set
        /// </summary>
        public decimal Checkout(decimal totalCost)
        {
            foreach (var c in ShoppingList)
            {
                totalCost += OrderTotal;
            }

            ShoppingList.Clear();
            return totalCost;
        }

        public void printShoppingCart()
        {
            try
            {
                Console.WriteLine("Items you have chosen: ");
                for (int i = 0; i < ShoppingList.Count; i++)
                {
                    Console.WriteLine("Print Inventory: " + ShoppingList[i]);
                }
                Console.WriteLine("The total cost of your items is:" + Checkout(OrderTotal));
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Sequence contains no elements", e);
            }
        }

        public void AddOrder()
        {
            Console.WriteLine("Which item would you like to buy?");
            int item = int.Parse(Console.ReadLine());
            Console.WriteLine("How many of these items?");
            int Quantity = int.Parse(Console.ReadLine());
            OrderTotal = CalculatePrice(item, Quantity);
            Console.WriteLine(OrderTotal);
            ShoppingList.Add(OrderID, CustomerID);
            for (int i = 0; i < ShoppingList.Count; i++)
            {
                Console.WriteLine("Order ID: " + OrderID + "and item:" + item + ShoppingList[i]);
            }
            OrderID++;
            Console.ReadLine();
        }

        public void RemoveOrder()
        {
            Console.WriteLine("Enter Order ID: ");
            int removeItem = int.Parse(Console.ReadLine());
            if (removeItem == OrderID)
                ShoppingList.Remove(OrderID);
        }

        public decimal CalculatePrice(int item, int quant)
        {
            switch (item)
            {
                case 1:
                    Price = 1M;
                    break;
                case 2:
                    Price = 1M;
                    break;
                case 3:
                    Price = 0.5M;
                    break;
            }
            Price = Price * quant;
            return Price;
        }
    }
}
