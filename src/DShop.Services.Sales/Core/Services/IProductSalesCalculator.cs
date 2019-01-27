using System.Collections.Generic;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Services
{
    public interface IProductSalesCalculator
    {
        IEnumerable<ProductSales> Calculate(IEnumerable<Product> products,
            IEnumerable<Order> orders);
    }
}