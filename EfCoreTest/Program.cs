using EfCoreTest.Data;
using EfCoreTest.Models;
using EfCoreTest.Services;
using System;
using System.Linq;

namespace EfCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using ShopContext context = new ShopContext();

            var shopService = new ShopService(context);
            //var products = shopService.GetProducts();
            //var products = shopService.GetProductsQuery().Where(p => p.Price >= 10.00M).OrderBy(p => p.Name);
            var products = shopService.GetProductsOrdered(Helpers.SortOrder.Desc);

            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}");
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new string('-', 20));
            }

            //var orders = shopService.GetOrders();
            var orders = shopService.GetOrdersWithDetails();

            foreach (var o in orders)
            {
                Console.WriteLine(new string('-', 10) + "Order" + new string('-', 10));
                Console.WriteLine($"Id: {o.Id}");
                Console.WriteLine($"Date: {o.OrderPlaced}");
                Console.WriteLine(new string('-', 10));
                foreach (var op in o.ProductOrders)
                {
                    Console.WriteLine($"Id: {op.Id}");
                    Console.WriteLine($"Product: {op.Product.Name}");
                    Console.WriteLine($"Price: {op.Product.Price}");
                    Console.WriteLine($"Quantity: {op.Quantity}");
                    Console.WriteLine(new string('-', 10));
                }
                Console.WriteLine($"Total price: {Math.Round(shopService.GetTotalPriceOrder(o.Id),2)}");
            }

            //ProductOrder po = new ProductOrder()
            //{
            //    OrderId = 1,
            //    ProductId = 1,
            //    Quantity = 5
            //};

            //ProductOrder po2 = new ProductOrder()
            //{
            //    OrderId = 2,
            //    ProductId = 2,
            //    Quantity = 2
            //};

            //ProductOrder po3 = new ProductOrder()
            //{
            //    OrderId = 1,
            //    ProductId = 2,
            //    Quantity = 10
            //};

            //context.Add(po);
            //context.Add(po2);
            //context.Add(po3);
            //context.SaveChanges();


            //Customer customerMichael = new Customer()
            //{
            //    FirstName = "Michaël",
            //    LastName = "Cloots",
            //    Email = "michael.cloots@thomasmore.be"
            //};

            //Customer customerJos = new Customer()
            //{
            //    FirstName = "Jos",
            //    LastName = "Jossen",
            //    Email = "jos.jossen@thomasmore.be"
            //};

            //context.Add(customerMichael);
            //context.Add(customerJos);

            //context.SaveChanges();

            //Order order = new Order()
            //{
            //    OrderPlaced = DateTime.Now,
            //    CustomerId = 1
            //};

            //Order order2 = new Order()
            //{
            //    OrderPlaced = DateTime.Now.AddDays(-7),
            //    CustomerId = 1
            //};

            //context.Add(order);
            //context.Add(order2);
            //context.SaveChanges();




            //var products = context.Products
            //    .Where(p => p.Price >= 5.00M)
            //    .OrderBy(p => p.Name);

            //var productsLinq = from product in context.Products
            //                   where product.Price >= 5.00M
            //                   orderby product.Name
            //                   select product;

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Id: {p.Id}");
            //    Console.WriteLine($"Name: {p.Name}");
            //    Console.WriteLine($"Price: {p.Price}");
            //    Console.WriteLine(new string('-',20));
            //}

            Console.ReadKey();

            //Product woodyPajamas = new Product()
            //{
            //    Name = "Red Woody pajama",
            //    Price = 15.99M
            //};
            //context.Products.Add(woodyPajamas);

            //Product redCap = new Product()
            //{
            //    Name = "Red cap",
            //    Price = 8.99M
            //};
            //context.Add(redCap);

            //Product blueTshirt = new Product()
            //{
            //    Name = "Blue t-shirt",
            //    Price = 19.99M
            //};
            //context.Add(blueTshirt);

            //context.SaveChanges();
        }
    }
}
