using Microsoft.EntityFrameworkCore;
using products_catalogue.Domain.Models;
using System;

namespace products_catalogue.Infrastructure.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Camiseta",
                Description = "Camiseta de algodón con estampado.",
                Category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Ropa",
                    Description = "Ropa para hombre y mujer."
                },
                Image = "https://example.com/images/camiseta.jpg",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },

             new Product
             {
                 Id = Guid.NewGuid(),
                 Name = "Zapatillas",
                 Description = "Zapatillas deportivas para correr.",
                 Category = new Category
                 {
                     Id = Guid.NewGuid(),
                     Name = "Calzado",
                     Description = "Calzado para hombre y mujer."
                 },
                 Image = "https://example.com/images/zapatillas.jpg",
                 CreatedDate = DateTime.UtcNow,
                 UpdatedDate = DateTime.UtcNow
             },

             new Product
             {
                 Id = Guid.NewGuid(),
                 Name = "Reloj",
                 Description = "Reloj de pulsera analógico.",
                 Category = new Category
                 {
                     Id = Guid.NewGuid(),
                     Name = "Accesorios",
                     Description = "Accesorios para hombre y mujer."
                 },
                 Image = "https://example.com/images/reloj.jpg",
                 CreatedDate = DateTime.UtcNow,
                 UpdatedDate = DateTime.UtcNow
             }
            );
        }
    }
}