using Microsoft.EntityFrameworkCore;
using CosmeticApp5.Models;

namespace CosmeticApp5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public object Product { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(

                 new Product
                 {
                     Id = 1,
                     Name = "Makarona Bareti",
                     Price = "230",
                     Address = "Tirane-Durres",
                     ModifiedDate = DateTime.Now,


                 });

        }

    }

}
