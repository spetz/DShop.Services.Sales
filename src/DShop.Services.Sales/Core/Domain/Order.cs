namespace DShop.Services.Sales.Core.Domain
{
    public class Order
    {
        public AggregateId Id { get; private set; }
        public AggregateId CustomerId { get; private set; }
        public string State { get; private set; }

        private Order()
        {
        }
        
        public Order(AggregateId id, AggregateId customerId)
        {
            Id = id;
            CustomerId = customerId;
            State = States.New;
        }

        public void Complete()
        {
            State = States.Completed;
        }
        
        public void Cancel()
        {
            State = States.Canceled;
        }

        public static class States
        {
            public static string New => "new";
            public static string Completed => "completed";
            public static string Canceled => "canceled";
        }
    }
}