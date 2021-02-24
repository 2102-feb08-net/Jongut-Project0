using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Library
{
    public class Inventory
    {
        public int InventoryID { get; private set; }

        public int StoreID { get; private set; }

        public int ProductID { get; private set; }

        public int Quantity { get; private set; }

        public Inventory(int storeId, int productId, int quantity)
        {
            StoreID = storeId;

            ProductID = productId;

            ValidateReasonableQuantity(quantity);

            quantity = Quantity;


        }

        private void ValidateReasonableQuantity(int quantity)
        {
            if (quantity > 100)
            {
                throw new ArgumentException("Unreasonable Quantity");
            }
        }
    }
}
