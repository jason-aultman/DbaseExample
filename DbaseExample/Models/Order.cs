using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbaseExample.Models
{
    public class Order
    {
        public int ID { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();


    }
}
