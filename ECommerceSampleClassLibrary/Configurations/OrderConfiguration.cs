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
            builder.HasOne(o => o.Customer).WithOne().HasForeignKey<Order>(o => o.CustomerId);
        }
    }
}
