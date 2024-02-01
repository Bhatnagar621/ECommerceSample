using ECommerceSampleClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSampleClassLibrary.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Measurement).HasMaxLength(256);
            builder.HasOne(x => x.Category).WithOne(c => c.Product);
            builder.HasMany(x => x.Orders).WithMany(o => o.Products);
        }
    }
}
