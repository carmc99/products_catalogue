using products_catalogue.Domain.Models;

namespace products_catalogue.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        //Definicion operaciones exclusivas IProductRepository
    }
}