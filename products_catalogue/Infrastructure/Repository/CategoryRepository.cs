using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.DbContexts;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace products_catalogue.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InMemoryContext dbContext;

        public CategoryRepository(InMemoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll(int pageNumber, int pageSize, string sortOrder)
        {
            var items = dbContext.Categories.AsQueryable();

            if (sortOrder.ToLower() == "desc")
            {
                items = items.OrderByDescending(c => c.Name);
            }
            else
            {
                items = items.OrderBy(c => c.Name);
            }

            return items.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public Category GetById(Guid id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Remove(Guid id)
        {
            var categoryToRemove = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryToRemove != null)
            {
                dbContext.Categories.Remove(categoryToRemove);
                dbContext.SaveChanges();
            }
        }

        public void Update(Guid id, Category entity)
        {
            var existingCategory = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = entity.Name;
                existingCategory.Description = entity.Description;
                existingCategory.UpdatedDate = DateTime.UtcNow;

                dbContext.SaveChanges();
            }
        }
    }

}