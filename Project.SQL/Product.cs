using System;
using System.Collections.Generic;

#nullable disable

namespace Project.SQL
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; } 
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderProduct>();
        }


        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderProduct> OrderLines { get; set; }
    }
}
