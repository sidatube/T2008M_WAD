using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace T2008M_WAD.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("T2008M")
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
    }
}