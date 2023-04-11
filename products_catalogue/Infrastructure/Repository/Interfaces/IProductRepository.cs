using products_catalogue.Domain.Models;
using System;
using System.Collections.Generic;

namespace products_catalogue.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Guid id, Product product);
        void Remove(Guid id);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll(int pageNumber, int pageSize, string sortOrder);
    }
}