using Microsoft.EntityFrameworkCore;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlServerContext dbContext;

        public CategoryRepository(SqlServerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> Add(Category entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            await dbContext.Categories.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<Category> GetAll(int pageNumber, int pageSize = 10, SortBy sortBy = SortBy.Name, OrderByDirection orderByDirection = OrderByDirection.Desc)
        {
            var items = dbContext.Categories.Include(c => c.Products).AsQueryable();

            switch (sortBy)
            {
                case SortBy.Name:
                    items = orderByDirection == OrderByDirection.Asc ? items.OrderBy(t => t.Name) : items.OrderByDescending(t => t.Name);
                    break;
                default:
                    throw new ArgumentException("Invalid SortBy value.");
            }

            return items.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public Category GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async void Remove(Guid id)
        {
            var categoryToRemove = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryToRemove != null)
            {
                dbContext.Categories.Remove(categoryToRemove);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Category> Update(Guid id, Category entity)
        {
            var existingCategory = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = entity.Name;
                existingCategory.Description = entity.Description;
                existingCategory.UpdatedDate = DateTime.UtcNow;

                await dbContext.SaveChangesAsync();
            }

            return existingCategory;
        }
    }

}