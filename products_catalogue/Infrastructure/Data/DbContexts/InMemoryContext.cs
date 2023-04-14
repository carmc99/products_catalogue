using Microsoft.EntityFrameworkCore;
using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Data.Seeders;

namespace products_catalogue.Infrastructure.DbContexts
{
    public class InMemoryContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Catalogue");
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(p => p.Products);

            modelBuilder.Seed();
        }
    }
}