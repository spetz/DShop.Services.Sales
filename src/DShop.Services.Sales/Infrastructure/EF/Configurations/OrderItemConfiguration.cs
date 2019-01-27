using DShop.Services.Sales.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DShop.Services.Sales.Infrastructure.EF.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(p => new {p.OrderId, p.ProductId});
            builder.Property(p => p.ProductId).HasAggregateIdConversion();
            builder.Property(p => p.OrderId).HasAggregateIdConversion();
            builder.HasOne<Order>().WithMany(o => o.Items).HasForeignKey(p => p.OrderId);
        }
    }
}