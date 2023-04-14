using Microsoft.EntityFrameworkCore;
using products_catalogue.Domain.Models;
using System;

namespace products_catalogue.Infrastructure.Data.Seeders
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var cat1 = new Category
            {
                Id = Guid.Parse("01234567-89ab-cdef-0123-456789abcdef"),
                Name = "Ropa",
                Description = "Ropa para hombre y mujer."
            };
            var cat2 = new Category
            {
                Id = Guid.Parse("11234567-89ab-cdef-0123-456789abcdef"),
                Name = "Calzado",
                Description = "Calzado para hombre y mujer."
            };

            modelBuilder.Entity<Category>().HasData(
                    cat1,
                    cat2
                );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Camiseta",
                Description = "Camiseta de algodón con estampado.",
                CategoryId = cat1.Id,
                Image = "https://example.com/images/camiseta.jpg",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },

             new Product
             {
                 Id = Guid.NewGuid(),
                 Name = "Zapatillas",
                 Description = "Zapatillas deportivas para correr.",
                 CategoryId = cat2.Id,
                 Image = "https://example.com/images/zapatillas.jpg",
                 CreatedDate = DateTime.UtcNow,
                 UpdatedDate = DateTime.UtcNow
             }
            );
        }
    }
}