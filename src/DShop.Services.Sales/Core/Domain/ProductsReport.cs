using System;
using System.Collections.Generic;

namespace DShop.Services.Sales.Core.Domain
{
    public class ProductsReport
    {
        public AggregateId Id { get; private set; }
        public IEnumerable<ProductRank> Products { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private ProductsReport()
        {
        }

        public ProductsReport(AggregateId id, IEnumerable<ProductRank> products)
        {
            Id = id;
            Products = products;
            CreatedAt = DateTime.UtcNow;
        }
    }
}