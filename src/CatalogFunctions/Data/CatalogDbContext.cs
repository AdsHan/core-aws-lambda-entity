using CatalogFunctions.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CatalogFunctions.Data;

public class CatalogDbContext : DbContext
{

    public CatalogDbContext()
    {

    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {

    }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
