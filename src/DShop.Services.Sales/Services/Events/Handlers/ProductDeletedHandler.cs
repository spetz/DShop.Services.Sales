using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace DShop.Services.Sales.Services.Events.Handlers
{
    public class ProductDeletedHandler : IEventHandler<ProductDeleted>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductCreatedHandler> _logger;

        public ProductDeletedHandler(IProductRepository productRepository,
            ILogger<ProductCreatedHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public Task HandleAsync(ProductDeleted @event, ICorrelationContext context)
        {
            _logger.LogInformation($"Deleting a product: {@event.Id}");
            return _productRepository.DeleteAsync(@event.Id);
        }
    }
}