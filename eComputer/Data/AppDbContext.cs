using System;
using System.Numerics;
using eComputer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eComputer.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComModel_Accessory>().HasKey(ca => new
            {
                ca.ComModelId,
                ca.AccessoryId
            });

            modelBuilder.Entity<ComModel_Accessory>().HasOne(c => c.ComModel).WithMany(ca => ca.ComModels_Accessories).HasForeignKey(c => c.ComModelId);
            modelBuilder.Entity<ComModel_Accessory>().HasOne(a => a.Accessory).WithMany(ca => ca.ComModels_Accessories).HasForeignKey(a => a.AccessoryId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Series> Serieses { get; set; }
        public DbSet<ComModel_Accessory> ComModels_Accessories { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ComModel> ComModels { get; set; }

        //Order realted tables
        public DbSet<ComOrder> ComOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}

