using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace products_catalogue.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll(int pageNumber, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
        }
    }
}