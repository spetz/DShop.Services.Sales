using System.Collections.Generic;
using System.Linq;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Services
{
    public class ProductSalesCalculator : IProductSalesCalculator
    {
        public IEnumerable<ProductSales> Calculate(IEnumerable<Product> products,
            IEnumerable<OrderItem> orderItems)
            => from product in products
                let totalSales = orderItems
                    .Where(i => i.ProductId.Equals(product.Id))
                    .Sum(i => i.Quantity)
                select new ProductSales(product.Id, totalSales);
    }
}