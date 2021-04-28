using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbaseExample.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Quantity  { get; set; }
        public string? Units { get; set; }
        public decimal? Price { get; set; }

        public int? OrderID { get; set; }
        public Order Order { get; set; }
       
    }
}
