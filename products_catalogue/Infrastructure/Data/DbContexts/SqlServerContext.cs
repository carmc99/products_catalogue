using Microsoft.EntityFrameworkCore;
using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Data.Seeders;
using System.Configuration;

namespace products_catalogue.Infrastructure.DbContexts
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SqlServer2017_docker_dev"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Seed();
        }
    }
}