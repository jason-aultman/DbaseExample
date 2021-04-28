using DbaseExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbaseExample.ViewModels
{
    public class OrderProductViewModel
    {
        public Order Order { get; set; }
        
        public int SelectedProduct { get; set; }
        public IEnumerable<Product> Products {get; set;}
    }
}
