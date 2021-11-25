using System;
using System.Collections.Generic;

namespace EfCoreTest.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        //Foreign key relationship
        public int CustomerId { get; set; }
        //Navigation property: 1 customer per order
        public Customer Customer { get; set; }
        //Navigation property
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}