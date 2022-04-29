using CatalogFunctions.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogFunctions.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).HasColumnType("VARCHAR(30)");
        builder.Property(p => p.Description).HasColumnType("VARCHAR(60)");
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();

        builder.ToTable("Products");
    }
}
