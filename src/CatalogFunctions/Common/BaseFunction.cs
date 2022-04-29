using Amazon.Lambda.APIGatewayEvents;

namespace CatalogFunctions.Common;

public abstract class BaseFunction
{
    public APIGatewayProxyResponse Return400()
    {
        return new APIGatewayProxyResponse
        {
            StatusCode = 400,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }

    public APIGatewayProxyResponse Return200(string body)
    {
        return new APIGatewayProxyResponse
        {
            Body = body,
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}
