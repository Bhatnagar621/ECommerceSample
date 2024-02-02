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
            builder.HasOne(x => x.Category).WithOne().HasForeignKey<Product>(p => p.CategoryId);
            //builder.HasMany(x => x.Orders).WithMany(o => o.Products)
            //    .UsingEntity(
            //        "OrderProduct",
            //        p => p.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductsId").HasPrincipalKey(nameof(Product.Id)),
            //        o => o.HasOne(typeof(Order)).WithMany().HasForeignKey("OrdersId").HasPrincipalKey(nameof(Order.Id)),
            //        l => l.HasKey("OrdersId", "ProductsId")); 
        }
    }
}
