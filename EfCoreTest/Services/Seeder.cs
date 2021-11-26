using EfCoreTest.Data;
using EfCoreTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Services
{
    public class Seeder
    {
        private readonly ShopContext _context;
        public Seeder(ShopContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Products.Any())
            {
                //Seeding data
                Customer customerMichael = new Customer()
                {
                    FirstName = "Michaël",
                    LastName = "Cloots",
                    Email = "michael.cloots@thomasmore.be"
                };

                Customer customerJos = new Customer()
                {
                    FirstName = "Jos",
                    LastName = "Jossen",
                    Email = "jos.jossen@thomasmore.be"
                };

                _context.Add(customerMichael);
                _context.Add(customerJos);

                Product woodyPajamas = new Product()
                {
                    Name = "Red Woody pajama",
                    Price = 15.99M
                };
                _context.Products.Add(woodyPajamas);

                Product redCap = new Product()
                {
                    Name = "Red cap",
                    Price = 8.99M
                };
                _context.Add(redCap);

                Product blueTshirt = new Product()
                {
                    Name = "Blue t-shirt",
                    Price = 19.99M
                };
                _context.Add(blueTshirt);

                Order order = new Order()
                {
                    OrderPlaced = DateTime.Now,
                    CustomerId = 1
                };

                Order order2 = new Order()
                {
                    OrderPlaced = DateTime.Now.AddDays(-7),
                    CustomerId = 1
                };

                _context.Add(order);
                _context.Add(order2);

                ProductOrder po = new ProductOrder()
                {
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5
                };

                ProductOrder po2 = new ProductOrder()
                {
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 2
                };

                ProductOrder po3 = new ProductOrder()
                {
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 10
                };

                _context.Add(po);
                _context.Add(po2);
                _context.Add(po3);

                _context.SaveChanges();
            }
        }
    }
}
