using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc.Northwind.Entities.Concrete;

namespace Mvc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Northwind;Integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
