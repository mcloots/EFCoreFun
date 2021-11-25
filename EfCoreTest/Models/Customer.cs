using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Models
{
    public class Customer
    {
#nullable enable
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //? = nullable
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
#nullable disable
        //Navigation property
        //Customer kan 0 of meer Orders hebben = 1 to many relationship
        public ICollection<Order> Orders { get; set; }
    }
}
