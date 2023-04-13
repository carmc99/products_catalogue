using products_catalogue.Domain.Enums;
using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.DbContexts;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace products_catalogue.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext dbContext;

        public ProductRepository(SqlServerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> Add(Product entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<Product> GetAll(int pageNumber, int pageSize = 10, SortBy sortBy = SortBy.Name, OrderByDirection orderByDirection = OrderByDirection.Descending)
        {
            var items = dbContext.Products.AsQueryable();

            switch (sortBy)
            {
                case SortBy.Name:
                    items = orderByDirection == OrderByDirection.Ascending ? items.OrderBy(t => t.Name) : items.OrderByDescending(t => t.Name);
                    break;
                case SortBy.Category:
                    items = orderByDirection == OrderByDirection.Ascending ? items.OrderBy(t => t.CategoryId) : items.OrderByDescending(t => t.CategoryId);
                    break;
                default:
                    throw new ArgumentException("Invalid SortBy value.");
            }

            return items.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public Product GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
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

        public async Task<Product> Update(Guid id, Product entity)
        {
            var existingProduct = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = entity.Name;
                existingProduct.Description = entity.Description;
                existingProduct.CategoryId = entity.CategoryId;
                existingProduct.Image = entity.Image;
                existingProduct.UpdatedDate = DateTime.UtcNow;

                await dbContext.SaveChangesAsync();
            }
            return existingProduct;
        }
    }
}