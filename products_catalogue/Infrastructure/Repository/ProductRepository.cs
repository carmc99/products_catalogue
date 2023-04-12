using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.DbContexts;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace products_catalogue.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InMemoryContext dbContext;

        public ProductRepository(InMemoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int pageSize = 10, string sortOrder = "desc")
        {
            var items = dbContext.Products.AsQueryable();

            if (sortOrder.ToLower() == "desc")
            {
                items = items.OrderByDescending(t => t.Name);
            }
            else
            {
                items = items.OrderBy(t => t.Name);
            }

            return items.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public Product GetById(Guid id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            var productToRemove = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                dbContext.Products.Remove(productToRemove);
                dbContext.SaveChanges();
            }
        }

        public void Update(Guid id, Product entity)
        {
            var existingProduct = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = entity.Name;
                existingProduct.Description = entity.Description;
                existingProduct.CategoryId = entity.CategoryId;
                existingProduct.Image = entity.Image;
                existingProduct.UpdatedDate = DateTime.UtcNow;

                dbContext.SaveChanges();
            }
        }
    }
}