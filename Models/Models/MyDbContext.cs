using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions options) :base(options) { }
        public DbSet<Item> items { get; set; }
        public DbSet<Store> stores { get; set; }

        public DbSet<Store_Item> store_Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Item>(new ItemConfiguration());
            modelBuilder.ApplyConfiguration<Store>(new StoreConfiguration());
            modelBuilder.ApplyConfiguration<Store_Item>(new Store_ItemConfiguration());
        }
    }
}
