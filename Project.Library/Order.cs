using System;
using System.Collections.Generic;

namespace Project.Library
{
    public class Order
    {
       public int OrderID { get; private set; }
        public int StoreID { get; private set; }
        public int CustomerID { get; private set; }
        public DateTime OrderTime { get; private set; }

        public Order(int customerid, int StoreId, DateTime Ordertime, int id = 0)
        {

            OrderID = id;

            CustomerID = customerid;

            StoreID = StoreId;

            OrderTime = Ordertime;

            
        }

        private int ValidQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            if (quantity > 999)
            { 
                throw new ArgumentException("Quantity is unreasonably high.");
            }

            return quantity;
        }
    }
}
