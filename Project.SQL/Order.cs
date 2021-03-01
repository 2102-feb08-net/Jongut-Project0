using System;
using System.Collections.Generic;

#nullable disable

namespace Project.SQL   
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime OrderTimes { get; set; }
        public int CustomerId { get; set; }
        public int StoreLocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
        public virtual ICollection<OrderProduct> OrderLines { get; set; }   
    }
}
