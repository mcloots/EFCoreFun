using EfCoreTest.Data;
using EfCoreTest.Helpers;
using EfCoreTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Services
{
    public class ShopService
    {
        private readonly ShopContext _context;
        public ShopService(ShopContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductsOrdered(SortOrder order)
        {
            switch (order)
            {
                case SortOrder.Asc:
                    return _context.Products.OrderBy(p => p.Name).ThenBy(p => p.Price).ToList();
                case SortOrder.Desc:
                    return _context.Products.OrderByDescending(p => p.Name).ThenByDescending(p => p.Price).ToList();
                default:
                    return _context.Products.ToList();
            }

        }

        public IQueryable<Product> GetProductsQuery()
        {
            return _context.Products.AsQueryable();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public decimal GetTotalPriceOrder(int orderId)
        {
            //.Include(p=>p.Product) is not needed
            return _context.ProductOrders.Where(po => po.OrderId == orderId).Sum(po => po.Quantity * po.Product.Price);
        }

        public List<Order> GetOrdersWithDetails()
        {
            return _context.Orders.Include(p => p.ProductOrders).ThenInclude(p => p.Product).ToList();
        }
    }
}
