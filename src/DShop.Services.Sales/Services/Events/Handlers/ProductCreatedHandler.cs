using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace DShop.Services.Sales.Services.Events.Handlers
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductCreatedHandler> _logger;

        public ProductCreatedHandler(IProductRepository productRepository,
            ILogger<ProductCreatedHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        
        public Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            _logger.LogInformation($"Adding a product: {@event.Id}");
            return _productRepository.AddAsync(new Product(@event.Id, @event.Name,
                @event.Vendor, @event.Price));
        }
    }
}