using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NorthwindContext : DbContext
    {
        const string ConnectionString = "host=localhost;db=NorthWind;uid=postgres;pwd=2709";

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnName("description");

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products);
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");


            modelBuilder.Entity<OrderDetails>().HasKey(d => new { d.OrderId, d.ProductId });
            modelBuilder.Entity<OrderDetails>().HasOne(d => d.Product).WithMany(p => p.OrderDetails);
            modelBuilder.Entity<OrderDetails>().HasOne(d => d.Order).WithMany(o => o.OrderDetails);
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(d => d.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(d => d.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(d => d.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().Property(d => d.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(d => d.ProductId).HasColumnName("productid");

            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails).WithOne(d => d.Order);
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(o => o.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(o => o.Shipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");
        }
    }
}
