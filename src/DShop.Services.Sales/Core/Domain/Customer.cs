namespace DShop.Services.Sales.Core.Domain
{
    public class Customer
    {
        public AggregateId Id { get; private set; }
        public string Email { get; private set; }

        private Customer()
        {
        }

        public Customer(AggregateId id, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                
            }

            Id = id;
            Email = email;
        }
    }
}