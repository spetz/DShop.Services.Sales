using DShop.Services.Sales.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DShop.Services.Sales.Infrastructure.EF.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id).HasAggregateIdConversion();
            builder.Property(p => p.CustomerId).HasAggregateIdConversion();
            builder.HasOne<Customer>().WithMany().HasForeignKey(p => p.CustomerId);
            builder.HasMany(o => o.Items);
        }
    }
}