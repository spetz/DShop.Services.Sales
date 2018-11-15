namespace DShop.Services.Sales.Services.Dto
{
    public class ProductRankDto
    {
        public int Rank { get; set; }
        public ProductDto Product { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalEarnings { get; set; }
    }
}