using System.Collections.Generic;
using System.Linq;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Exceptions;
using DShop.Services.Sales.Core.Services;

namespace DShop.Services.Sales.Core.Factories
{
    public class ProductsReportFactory : IProductsReportFactory
    {
        private readonly IProductSalesCalculator _salesCalculator;

        public ProductsReportFactory(IProductSalesCalculator salesCalculator)
        {
            _salesCalculator = salesCalculator;
        }
        
        public ProductsReport Create(AggregateId id, IEnumerable<Product> products,
            IEnumerable<OrderItem> orderItems, int maxRank)
        {
            if (products == null || !products.Any())
            {
                throw new EmptyProductsException();
            }

            if (orderItems == null || !orderItems.Any())
            {
                throw new EmptyOrderItemsException();
            }

            maxRank = maxRank > 0 ? maxRank : 3;
            var productsSales = _salesCalculator.Calculate(products, orderItems);
            var rankings = new List<ProductRank>();
            var currentRank = 1;
            foreach (var sales in productsSales.OrderByDescending(p => p.TotalSales))
            {
                var product = products.Single(p => p.Id.Equals(sales.ProductId));
                var totalEarnings = product.Price * sales.TotalSales;
                var rank = new ProductRank(product.Id, product.Name, product.Price,
                    product.Vendor, currentRank, sales.TotalSales, totalEarnings);
                rankings.Add(rank);
                if (currentRank == maxRank)
                {
                    break;
                }

                currentRank++;
            }

            return new ProductsReport(id, rankings);
        }
    }
}