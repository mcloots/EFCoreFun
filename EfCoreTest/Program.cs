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

            Seeder seeder = new Seeder(context);
            seeder.Seed();

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

            Console.ReadKey();
        }
    }
}
