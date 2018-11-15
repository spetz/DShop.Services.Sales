using System.Collections.Generic;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Factories
{
    public interface IProductsReportFactory
    {
        ProductsReport Create(AggregateId id, IEnumerable<Product> products,
            IEnumerable<OrderItem> orderItems, int maxRank);
    }
}