using CatalogFunctions.Data.Entities;

namespace CatalogFunctions.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public static ProductDTO ToProductDTO(ProductModel product)
    {
        return new ProductDTO()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
        };
    }
}
