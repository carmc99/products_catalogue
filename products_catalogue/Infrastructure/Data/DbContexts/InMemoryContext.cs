using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Data.Seeders;

namespace products_catalogue.Infrastructure.DbContexts
{
    public class InMemoryContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var inMemoryDatabaseRoot = new InMemoryDatabaseRoot();

            optionsBuilder.UseInMemoryDatabase("Catalogue", inMemoryDatabaseRoot);
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