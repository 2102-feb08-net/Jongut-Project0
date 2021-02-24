using System;
using System.Collections.Generic;

#nullable disable

namespace Project.SQL
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime? OrderTime { get; set; }
        public int CustomerID { get; set; }
        public int StoreID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
