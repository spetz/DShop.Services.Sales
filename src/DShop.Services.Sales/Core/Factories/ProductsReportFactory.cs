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
        
        public ProductsReport Create(AggregateId id, IReadOnlyCollection<Product> products,
            IReadOnlyCollection<Order> orders, int maxRank)
        {
            if (products == null || !products.Any())
            {
                throw new EmptyProductsException();
            }

            if (orders == null || !orders.Any())
            {
                throw new EmptyOrdersException();
            }

            maxRank = maxRank > 0 ? maxRank : 3;
            var productsSales = _salesCalculator.Calculate(products, orders);
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