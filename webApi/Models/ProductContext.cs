using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using webApi.Models;

namespace webApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { 
        }
         
    

        public DbSet<Product> Products { get; set; }
        public object Product { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Iphone11",
                Price=14.5,
                Description="Iphone 11 series, retina HD",

            }, new Product
            {
                Id=2,
                Name = "Samsung Galaxy",
                Price = 15.5,
                Description = "Powerfull chip",
            }); 
        }
    }

    
}
