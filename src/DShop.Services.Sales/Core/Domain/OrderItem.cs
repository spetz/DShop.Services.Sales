using System;

namespace DShop.Services.Sales.Core.Domain
{
    //Value object
    public class OrderItem : IEquatable<OrderItem>
    {
        public AggregateId OrderId { get; private set; }
        public AggregateId ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        private OrderItem()
        {
        }
        
        public OrderItem(AggregateId orderId, AggregateId productId, decimal price, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = price;
            Quantity = quantity;
            TotalPrice = UnitPrice * Quantity;
        }

        public bool Equals(OrderItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(OrderId, other.OrderId) && Equals(ProductId, other.ProductId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrderId != null ? OrderId.GetHashCode() : 0) * 397) ^ (ProductId != null ? ProductId.GetHashCode() : 0);
            }
        }
    }
}