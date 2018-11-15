namespace DShop.Services.Sales.Core.Domain
{
    public class OrderItem
    {
        public AggregateId OrderId { get; private set; }
        public AggregateId ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        private OrderItem()
        {
        }
        
        public OrderItem(AggregateId orderId, AggregateId productId, 
            decimal price, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = price;
            Quantity = quantity;
            TotalPrice = UnitPrice * Quantity;
        }
    }
}