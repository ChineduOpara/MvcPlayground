using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcPlayground.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
    }
}
