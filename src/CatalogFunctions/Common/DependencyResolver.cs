using CatalogFunctions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogFunctions.Common;

public class DependencyResolver
{
    public IServiceProvider ServiceProvider { get; }
    public Action<IServiceCollection> RegisterServices { get; }

    public DependencyResolver(Action<IServiceCollection> registerServices = null)
    {
        var serviceCollection = new ServiceCollection();
        RegisterServices = registerServices;
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer("Server=localhost,1433;Initial Catalog=CatalogDB;Integrated Security=True;Trusted_Connection=False;User Id=sa;Password=MyPass@word"));

        services.AddLogging(logging =>
        {
            logging.AddLambdaLogger();
            logging.SetMinimumLevel(LogLevel.Debug);
        });

        RegisterServices?.Invoke(services);

        /*
        CREATE TABLE [Products] (
            [Id] int NOT NULL,
            [Title] nvarchar(max) NULL,
            [Description] nvarchar(max) NULL,
            [Price] float NOT NULL,
            [Quantity] int NOT NULL,
            [Status] int NOT NULL,
            [DateCreateAt] datetime2 NOT NULL,
            [DateDeleteAt] datetime2 NULL,
            CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
        );
        */
    }
}
