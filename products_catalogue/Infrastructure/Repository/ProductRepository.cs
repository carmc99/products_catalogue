using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace products_catalogue.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
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