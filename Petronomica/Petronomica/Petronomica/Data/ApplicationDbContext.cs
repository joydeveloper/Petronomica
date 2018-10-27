using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Petronomica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Products.Product> Products { get; set; }
        public DbSet<Orders.Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
  

    
    }
}
