using Microsoft.EntityFrameworkCore;
using MotoEshop.Models.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Database
{
    public class EshopDBContext : DbContext
    {
        public EshopDBContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
