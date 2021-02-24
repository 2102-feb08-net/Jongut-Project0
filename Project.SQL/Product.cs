using System;
using System.Collections.Generic;

#nullable disable

namespace Project.SQL
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
