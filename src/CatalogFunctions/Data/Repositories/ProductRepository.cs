using CatalogFunctions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogFunctions.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductModel>> GetAllAsync()
    {
        return await _dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<ProductModel> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task UpdateAsync(ProductModel product)
    {
        // Reforço que a entidade foi alterada
        _dbContext.Entry(product).State = EntityState.Modified;
        _dbContext.Update(product);
    }

    public async Task AddAsync(ProductModel product)
    {
        _dbContext.Add(product);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

}
