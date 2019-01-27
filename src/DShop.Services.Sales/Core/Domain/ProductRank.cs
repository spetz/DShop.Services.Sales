using System;

namespace DShop.Services.Sales.Core.Domain
{
    //Value object
    public class ProductRank : IEquatable<ProductRank>
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

        public bool Equals(ProductRank other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductRank) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}