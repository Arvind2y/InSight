using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babble.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAdress { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Customer Customer { get; set; }
    }
}