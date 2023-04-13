using products_catalogue.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace products_catalogue.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Add(T product);
        Task<T> Update(Guid id, T entity);
        void Remove(Guid id);
        T GetById(Guid id);
        IEnumerable<T> GetAll(int pageNumber, int pageSize = 10, SortBy sortBy = SortBy.Name, OrderByDirection orderByDirection = OrderByDirection.Descending);
    }
}
