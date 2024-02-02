using ECommerceSampleClassLibrary.Configurations;
using ECommerceSampleClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSampleClassLibrary.Context
{
    public class AppDbContext: DbContext
    {
        //public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ECommerceSample;Username=postgres;Password=Asdf!234;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        }
    }
}
