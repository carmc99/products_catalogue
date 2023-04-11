using products_catalogue.Domain.Models;
using System.Collections.Generic;

namespace products_catalogue.Infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        IEnumerable<Category> GetAll(int pageNumber, int pageSize, string sortOrder);
    }
}
