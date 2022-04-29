using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using CatalogFunctions.Common;
using CatalogFunctions.Data.Repositories;
using CatalogFunctions.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CatalogFunctions;

public class Function : BaseFunction
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<Function> _logger;

    public Function()
    {
        var resolver = new DependencyResolver(ConfigureServices);

        _productRepository = resolver.ServiceProvider.GetService<IProductRepository>();
        _logger = resolver.ServiceProvider.GetRequiredService<ILogger<Function>>();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        if (!request.PathParameters.ContainsKey("Id")) return Return400();

        var input = request.PathParameters["Id"];
        int.TryParse(input, out var id);

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null) return Return400();

        return Return200(JsonSerializer.Serialize(ProductDTO.ToProductDTO(product)));
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
    }
}
