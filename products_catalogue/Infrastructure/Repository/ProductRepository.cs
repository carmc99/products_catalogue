using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Context;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace products_catalogue.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}