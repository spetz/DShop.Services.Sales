using DShop.Services.Sales.Core.Exceptions;

namespace DShop.Services.Sales.Core.Domain
{
    public class Product
    {
        public AggregateId Id { get; private set; }
        public string Name { get; private set; }
        public string Vendor { get; private set; }
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public Product(AggregateId id, string name, string vendor, decimal price)
        {
            Id = id;
            SetName(name);
            SetVendor(vendor);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidProductNameException();
            }

            Name = name;
        }

        public void SetVendor(string vendor)
        {
            if (string.IsNullOrWhiteSpace(vendor))
            {
                throw new InvalidProductNameException();
            }

            Vendor = vendor;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new InvalidProductPriceException();
            }

            Price = price;
        }
    }
}