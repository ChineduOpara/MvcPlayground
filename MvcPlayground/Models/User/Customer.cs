using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcPlayground.Models.User
{
    public class Customer : CitkaUserProfile
    {
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public IEnumerable<MvcPlayground.Models.Order.Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order.Order>();
        }
    }
}
