namespace DShop.Services.Sales.Core.Domain
{
    //Value object
    public class ProductRank
    {
        public AggregateId Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public string Vendor { get; }
        public int Rank { get; }
        public int TotalSales { get; }
        public decimal TotalEarnings { get; }

        private ProductRank()
        {
        }
        
        public ProductRank(AggregateId id, string name, decimal price, 
            string vendor, int rank, int totalSales, decimal totalEarnings)
        {
            Id = id;
            Name = name;
            Price = price;
            Vendor = vendor;
            Rank = rank;
            TotalSales = totalSales;
            TotalEarnings = totalEarnings;
        }
    }
}