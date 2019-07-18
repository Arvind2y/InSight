using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSEDemo.LINQ
{
    public class LinqExercise
    {
        internal class Order
        {
            public int OrderId { get; set; }
            public string ItemName { get; set; }
            public DateTime OrderDate { get; set; }
            public int Quantity { get; set; }
            public List<Item> OrderItems { get; set; }
        }

        internal class Item
        {
            public string ItemName { get; set; }
            public double Price { get; set; }
        }


        internal class ProductOrder
        {
            public int OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public List<OrderItem> OrderItems { get; set; }
        }

        internal class OrderItem
        {
            public string ItemName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }

        static List<Order> orders = null;
        static List<Item> items = null;

        static List<ProductOrder> productOrders = null;

        static LinqExercise()
        {
            orders = new List<Order> {
                new Order { OrderId=1, ItemName="Keyboard",OrderDate= new DateTime(2018, 12, 25, 08, 30, 40), Quantity=10,
                    OrderItems =new List<Item> {
                            new Item(){ ItemName="Keyboard", Price=450.00},
                            new Item(){ ItemName="Mouse", Price=500.00},
                            new Item(){ ItemName="Hard Disk", Price=4500.00},
                            new Item(){ ItemName="Monitor", Price=8715.00},
                            new Item(){ ItemName="Modem", Price=2250.00}
                    }
                },
                new Order { OrderId=2, ItemName="Mouse",OrderDate= new DateTime(2018, 12, 25, 10, 11, 10), Quantity=15 },
                new Order { OrderId=3, ItemName="Hard Disk",OrderDate= new DateTime(2018, 11, 25, 10, 30, 50), Quantity=25 },
                new Order { OrderId=4, ItemName="Monitor",OrderDate= new DateTime(2018, 11, 25, 11, 30, 20), Quantity=8 },
                new Order { OrderId=5, ItemName="Modem",OrderDate= new DateTime(2018, 12, 25, 13, 45, 55), Quantity=12},
            };

            items = new List<Item> {
                new Item(){ ItemName="Keyboard", Price=450.00},
                new Item(){ ItemName="Mouse", Price=500.00},
                new Item(){ ItemName="Hard Disk", Price=4500.00},
                new Item(){ ItemName="Monitor", Price=8715.00},
                new Item(){ ItemName="Modem", Price=2250.00}
            };


            productOrders = new List<ProductOrder> {
                new ProductOrder { OrderId=1, OrderDate= new DateTime(2018, 12, 25, 08, 30, 40),
                    OrderItems =new List<OrderItem> {
                            new OrderItem(){ ItemName="Keyboard", Price=450.00, Quantity=10},
                            new OrderItem(){ ItemName="Mouse", Price=500.00, Quantity=12},
                            new OrderItem(){ ItemName="Hard Disk", Price=4500.00, Quantity=5},
                            new OrderItem(){ ItemName="Monitor", Price=8715.00, Quantity=10},
                            new OrderItem(){ ItemName="Modem", Price=2250.00, Quantity=5}
                    }
                },
                new ProductOrder { OrderId=2, OrderDate= new DateTime(2018, 12, 25, 10, 11, 10), OrderItems =new List<OrderItem> {
                            new OrderItem(){ ItemName="Keyboard", Price=450.00, Quantity=1},
                            new OrderItem(){ ItemName="Mouse", Price=500.00, Quantity=1},
                            new OrderItem(){ ItemName="Hard Disk", Price=4500.00, Quantity=2},
                            new OrderItem(){ ItemName="Monitor", Price=8715.00, Quantity=1},
                    }
                },
                new ProductOrder { OrderId=3, OrderDate= new DateTime(2018, 11, 25, 10, 30, 50),OrderItems =new List<OrderItem> {
                            new OrderItem(){ ItemName="Keyboard", Price=450.00, Quantity=10},
                            new OrderItem(){ ItemName="Mouse", Price=500.00, Quantity=12},
                            new OrderItem(){ ItemName="Monitor", Price=8715.00, Quantity=10},
                            new OrderItem(){ ItemName="Modem", Price=2250.00, Quantity=5}
                    }
                },
                new ProductOrder { OrderId=4, OrderDate= new DateTime(2018, 11, 25, 11, 30, 20), OrderItems =new List<OrderItem> {
                            new OrderItem(){ ItemName="Keyboard", Price=450.00, Quantity=10},
                            new OrderItem(){ ItemName="Mouse", Price=500.00, Quantity=12},
                            new OrderItem(){ ItemName="Hard Disk", Price=4500.00, Quantity=5},
                            new OrderItem(){ ItemName="Monitor", Price=8715.00, Quantity=10},
                            new OrderItem(){ ItemName="Modem", Price=2250.00, Quantity=5}
                    }
                },
                new ProductOrder { OrderId=5, OrderDate= new DateTime(2018, 12, 25, 13, 45, 55), OrderItems =new List<OrderItem> {
                            new OrderItem(){ ItemName="Keyboard", Price=450.00, Quantity=10},
                            new OrderItem(){ ItemName="Mouse", Price=500.00, Quantity=12},
                            new OrderItem(){ ItemName="Hard Disk", Price=4500.00, Quantity=5},
                            new OrderItem(){ ItemName="Monitor", Price=8715.00, Quantity=10},
                            new OrderItem(){ ItemName="Modem", Price=2250.00, Quantity=5}
                    }
                }
            };
        }

        public static void GetNumberCube()
        {
            //1.Given an array of numbers. Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.
            int[] numbers = { 3, 5, 10, 50, 60, 100, 150, 200, 250, 300, 900, 1001, 2000 };

            IEnumerable<string> cubeQuery = from n in numbers
                                            where n > 100 && n < 1000
                                            select $"Cube of {n} = {n * n * n }";
            foreach (var num in cubeQuery)
            {
                Console.WriteLine(num);
            }

            var numCube = from n in numbers
                          let cube = Math.Pow(n, 3)
                          where n > 100 && n < 1000
                          select new { Num = n, NumCube = cube };

            foreach (var item in numCube)
            {
                Console.WriteLine($"Cube of {item.Num} = {item.NumCube}.");
            }

        }

        public static void ShowLatestOrders()
        {
            Console.WriteLine("\nLatest orders :");
            var latestOrders = from o in orders
                               orderby o.OrderDate descending
                               select o;
            foreach (var order in latestOrders)
            {
                Console.WriteLine($" {order.Quantity} {order.ItemName} is ordered at {order.OrderDate}.");
            }
        }

        public static void ShowOrdersByQuantity()
        {
            Console.WriteLine("\nOrders by quantity:");
            var latestOrders = from o in orders
                               orderby o.Quantity descending
                               select o;
            foreach (var order in latestOrders)
            {
                Console.WriteLine($" {order.Quantity} {order.ItemName} is ordered at {order.OrderDate}.");
            }
        }

        public static void GroupOrdersbyMonth()
        {
            Console.WriteLine("\nOrder by Month");

            var orderGroups = from o in orders
                              orderby o.OrderDate descending
                              group o by o.OrderDate.Month into g
                              select new { Month = g.Key, Orders = g };

            foreach (var item in orderGroups)
            {
                foreach (var mo in item.Orders)
                {
                    Console.WriteLine($"{mo.OrderDate.ToString("MMM-yyyy")} Orders : {mo.ItemName}, quantity : {mo.Quantity}");
                }
            }
        }

        public static void GetOrderIterDetails()
        {
            Console.WriteLine("\nOrder item details defined class");

            //var orderGroups = from o in orders
            //                  join i in items on o.ItemName equals i.ItemName into 
            //                  orderby o.OrderDate descending
            //                  group o by o.OrderDate.Month into g
            //                  select new { Month = g.Key, Orders = g, Price=o };

            List<OrderDetails> orderDetails = (from o in orders
                                               from i in items
                                               where o.ItemName == i.ItemName
                                               orderby o.OrderDate descending
                                               select new OrderDetails { OrderId = o.OrderId, OrderItemName = o.ItemName, OrderDate = o.OrderDate, ItemPrice = i.Price, Quantity = o.Quantity, TotalPrice = i.Price * o.Quantity }).ToList();

            foreach (var mo in orderDetails)
            {
                Console.WriteLine($"{mo.OrderDate.ToString("MMM-yyyy")} Orders : {mo.OrderItemName} {mo.Quantity} * {mo.ItemPrice} = Total Price {mo.TotalPrice}");
            }

            Console.WriteLine("\nOrder item details with anonymous type");

            var orderGroups = from o in orders
                              from i in items
                              where o.ItemName == i.ItemName
                              orderby o.OrderDate descending
                              select new { o.OrderId, o.ItemName, o.OrderDate, ItemPrice = i.Price, o.Quantity, TotalPrice = i.Price * o.Quantity };

            foreach (var mo in orderGroups)
            {
                Console.WriteLine($"{mo.OrderDate.ToString("MMM-yyyy")} Orders : {mo.ItemName} {mo.Quantity} * {mo.ItemPrice} = Total Price {mo.TotalPrice}");
            }
        }

        public static void CheckOrderQuantity()
        {
            Console.WriteLine("\nOrder Quantity :");
            var latestOrders = from o in orders
                               where o.Quantity > 0
                               orderby o.OrderDate descending
                               select o;
            foreach (var order in latestOrders)
            {
                Console.WriteLine($" {order.Quantity} {order.ItemName} is ordered at {order.OrderDate}.");
            }
        }


        public static void GetHighestQuantityItem()
        {
            //var item = productOrders.OrderBy(o=> o.OrderItems)


            ////select new { o.OrderId, o.ItemName}).Take(1);

            //foreach (var mo in largestQuantityItem)
            //{
            //    Console.WriteLine($" Orders Id :{mo.OrderId}, Item Name:  {mo.HighestQty}.");
            //}
        }


    }
}
