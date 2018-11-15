namespace DShop.Services.Sales.Core.Domain
{
    public class ProductSales
    {
        public AggregateId ProductId { get; }
        public int TotalSales { get; }

        public ProductSales(AggregateId productId, int totalSales)
        {
            ProductId = productId;
            TotalSales = totalSales;
        }
    }
}