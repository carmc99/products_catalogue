using System;
using System.Collections.Generic;

namespace products_catalogue.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T product);
        void Update(Guid id, T entity);
        void Remove(Guid id);
        T GetById(Guid id);
        IEnumerable<T> GetAll(int pageNumber, int pageSize = 10, string sortOrder = "desc");
    }
}
