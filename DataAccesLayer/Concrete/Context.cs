using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer.Concrete;

namespace DataAccesLayer.Concrete
{
    class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-Q3H4FFS;database=NewOopCore;integrated security=true;");

        }

        //public DbSet<Product> MyProperty { get; set; }



    }
}
