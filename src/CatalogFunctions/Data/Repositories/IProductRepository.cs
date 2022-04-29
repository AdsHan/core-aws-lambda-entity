using CatalogFunctions.Data.DomainObjects;
using CatalogFunctions.Data.Entities;

namespace CatalogFunctions.Data.Repositories;

public interface IProductRepository : IRepository<ProductModel>
{
    Task<List<ProductModel>> GetAllAsync();
    Task<ProductModel> GetByIdAsync(int id);
    Task AddAsync(ProductModel product);
    Task UpdateAsync(ProductModel product);
}
