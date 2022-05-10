using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MotoEshop.Models.Database.Configuration;
using MotoEshop.Models.Database.Converter;
using MotoEshop.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Database
{
    public class EshopDBContext : IdentityDbContext<User, Role, int>
    {
        IEnumerable<IDbContextOptionsExtension> optionsExtention;
        public EshopDBContext(DbContextOptions options) : base(options)
        {
            if (options != null)
                this.optionsExtention = options.Extensions;
        }
        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.Replace("AspNet", String.Empty);
            }
            int stringLength = 256;
            //modelBuilder.Entity<User>(entity => entity.Property(m => m.Id).HasMaxLength(stringLength));
            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(stringLength));
            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(stringLength));

            //modelBuilder.Entity<Role>(entity => entity.Property(m => m.Id).HasMaxLength(stringLength));
            modelBuilder.Entity<Role>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(stringLength));

            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(stringLength));
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(stringLength));
            //modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(stringLength));
            //modelBuilder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(stringLength));

            //modelBuilder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(stringLength));

            //modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(stringLength));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(stringLength));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(stringLength));

            //modelBuilder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(stringLength));
            //modelBuilder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(stringLength));
            //modelBuilder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(stringLength));
            //modelBuilder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(stringLength));

            if (optionsExtention != null & optionsExtention.Count() > 0)
            {
                foreach (var optionExtention in optionsExtention)
                {
                    if (optionExtention.GetType() == typeof(MySql.Data.EntityFrameworkCore.Infraestructure.MySQLOptionsExtension))
                    {
                        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                        {
                            foreach (var property in entityType.GetProperties())
                            {
                                if (property.ClrType == typeof(bool))
                                {
                                    property.SetValueConverter(new BoolToIntConverter());
                                }
                            }
                        }

                        break;
                    }
                }

            }

            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
