using ECommerceSampleClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSampleClassLibrary.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(256);

            builder.HasMany(o => o.Products).WithMany(p => p.Orders).UsingEntity(
                "OrderProduct",
                    p => p.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductsId").HasPrincipalKey(nameof(Product.Id)),
                    o => o.HasOne(typeof(Order)).WithMany().HasForeignKey("OrdersId").HasPrincipalKey(nameof(Order.Id)),
                    l => l.HasKey("OrdersId", "ProductsId"));

            builder.HasOne(o => o.Customer).WithOne().HasForeignKey<Order>(o => o.CustomerId);
        }
    }
}
