using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;// sd de thao tac vs file thu muc
using Microsoft.Extensions.Configuration;// sd doc file 
using Microsoft.EntityFrameworkCore;

namespace BTCK_PhanTienDo.Models
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //Directory.GetCurrentDirectory() -> tra ve duong dan thu muc folder hien tai
            var configuration = builder.Build();
            string strDBConnectString = configuration.GetConnectionString("DBConnectString").ToString();
            optionsBuilder.UseSqlServer(strDBConnectString);
        }
    
        public DbSet<UsersRecord> Users { get; set; }
        // truy van linq
        public DbSet<CategoriesRecord> Categories { get; set; }
        public DbSet<ProductsRecord> Products { get; set; }
        public DbSet<NewsRecord> News { get; set; }
        public DbSet<RatingRecord> Rating { get; set; }
        public DbSet<CustomersRecord> Customers { get; set; }
        public DbSet<OrdersRecord> Orders { get; set; }
        public DbSet<OrdersDetailRecord> OrdersDetail { get; set; }
        public DbSet<SlidesRecord> Slides { get; set; }
        public DbSet<AdvRecord> Adv { get; set; }
        public DbSet<RoleRecord> Role { get; set; }
    }
}
