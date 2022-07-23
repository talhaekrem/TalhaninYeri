using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;
using Microsoft.Extensions.Configuration.Json;

namespace TalhaninYeri.Northwind.DAL.Concreate.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(b => b.Description).IsRequired(false);
            modelBuilder.Entity<Product>().Property(i => i.ImagePath).IsRequired(false);

            modelBuilder.Entity<Slider>().Property(i => i.ImagePath).IsRequired(false);
            modelBuilder.Entity<Slider>().Property(i => i.Title).IsRequired(false);
            modelBuilder.Entity<Slider>().Property(i => i.Description).IsRequired(false);

            modelBuilder.Entity<SiteSetting>().Property(i => i.SiteName).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Instagram).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Twitter).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Youtube).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.GoogleMap).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Description).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Phone).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Address).IsRequired(false);
            modelBuilder.Entity<SiteSetting>().Property(i => i.Email).IsRequired(false);

            modelBuilder.Entity<OrderDetails>().HasKey(t => t.OrderDetailsID);
            modelBuilder.Entity<OrderDetails>().Property(i => i.OrderDetailsID).ValueGeneratedOnAdd();

            modelBuilder.Entity<ImageGallery>().HasKey(t => t.ImageId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<SiteSetting> SiteSetting { get; set; }
        public DbSet<ImageGallery> ImageGallery { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
    }
}
