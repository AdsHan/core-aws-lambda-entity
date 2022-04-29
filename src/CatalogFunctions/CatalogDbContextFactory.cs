using CatalogFunctions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CatalogFunctions;

public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=CatalogDB;Integrated Security=True;Trusted_Connection=False;User Id=sa;Password=MyPass@word");

        return new CatalogDbContext(optionsBuilder.Options);
    }
}
