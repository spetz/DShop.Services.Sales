using System;
using System.Collections.Generic;
using System.Linq;
using DShop.Services.Sales.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DShop.Services.Sales.Infrastructure.EF.Configurations
{
    public class ProductsReportConfiguration : IEntityTypeConfiguration<ProductsReport>
    {
        private readonly IEfJsonSerializer _jsonSerializer;

        public ProductsReportConfiguration(IEfJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public void Configure(EntityTypeBuilder<ProductsReport> builder)
        {
            builder.Property(p => p.Id).HasAggregateIdConversion();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Products).IsRequired()
                .HasConversion(p => _jsonSerializer.Serialize(p.Select(r => new ProductRankData
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Price = r.Price,
                        Vendor = r.Vendor,
                        Rank = r.Rank,
                        TotalSales = r.TotalSales,
                        TotalEarnings = r.TotalSales
                    })),
                    p => _jsonSerializer.Deserialize<IEnumerable<ProductRankData>>(p)
                        .Select(r =>
                            new ProductRank(new AggregateId(r.Id), r.Name, r.Price, r.Vendor, r.Rank, r.TotalSales,
                                r.TotalEarnings)));
        }

        private class ProductRankData
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Vendor { get; set; }
            public decimal Price { get; set; }
            public int Rank { get; set; }
            public int TotalSales { get; set; }
            public decimal TotalEarnings { get; set; }
        }
    }
}