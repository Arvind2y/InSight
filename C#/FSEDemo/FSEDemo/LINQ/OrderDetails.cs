
namespace FSEDemo.LINQ
{
    using System;
    internal class OrderDetails
    {
        public int OrderId { get; set; }
        public string OrderItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public double ItemPrice { get; set; }
        public double TotalPrice { get; set; }

        public int Quantity { get; set; }

    }
}