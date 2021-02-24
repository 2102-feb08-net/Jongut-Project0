using System;
using System.Collections.Generic;

#nullable disable

namespace Project.SQL
{
    public partial class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreLocation Store { get; set; }
    }
}
