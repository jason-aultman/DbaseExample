using DbaseExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbaseExample.Data
{
    public class DbaseExampleContext: DbContext
    {
        public DbaseExampleContext(DbContextOptions<DbaseExampleContext> options):base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
