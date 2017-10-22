using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace woodenitems.Models
{
    public class WoodenContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<MyImage> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}