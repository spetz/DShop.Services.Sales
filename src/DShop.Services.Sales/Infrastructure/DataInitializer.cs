using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DShop.Services.Sales.Infrastructure
{
    public class DataInitializer : IDataInitializer
    {
        private readonly Random _random = new Random();
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOptions<ApplicationOptions> _applicationOptions;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IOptions<ApplicationOptions> applicationOptions,
            ILogger<DataInitializer> logger)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _applicationOptions = applicationOptions;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            if (!_applicationOptions.Value.SeedData)
            {
                _logger.LogInformation("Data initialization skipped.");

                return;
            }

            _logger.LogInformation("Initializing data...");

            var customers = GetCustomers().ToList();
            var products = GetProducts().ToList();

            foreach (var customer in customers)
            {
                await _customerRepository.AddAsync(customer);
            }

            foreach (var product in products)
            {
                await _productRepository.AddAsync(product);
            }

            var orders = GetOrders(customers, products).ToList();
            foreach (var order in orders)
            {
                await _orderRepository.AddAsync(order);
            }

            _logger.LogInformation("Data initialized.");
        }

        private IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer(new AggregateId(), "customer1@dshop.com");
            yield return new Customer(new AggregateId(), "customer2@dshop.com");
        }

        private IEnumerable<Product> GetProducts()
        {
            yield return new Product(new AggregateId(), "IPhone 8", "Apple", 3000);
            yield return new Product(new AggregateId(), "IPhone XS", "Apple", 5000);
            yield return new Product(new AggregateId(), "S8", "Samsung", 2500);
            yield return new Product(new AggregateId(), "S9", "Samsung", 4000);
            yield return new Product(new AggregateId(), "Mi 6", "Xiaomi", 1500);
            yield return new Product(new AggregateId(), "Mi 8", "Xiaomi", 2200);
        }

        private IEnumerable<Order> GetOrders(IList<Customer> customers, IList<Product> products)
            => customers.Select(c =>
            {
                var orderId = new AggregateId();
                return new Order(orderId, c.Id, GetOrderItems(orderId, products));
            });

        private IEnumerable<OrderItem> GetOrderItems(AggregateId orderId, IList<Product> products)
            => products.Take(_random.Next(products.Count() / 2, products.Count() + 1))
                .Select(p => new OrderItem(orderId, p.Id, p.Price, _random.Next(1, 10)));
    }
}