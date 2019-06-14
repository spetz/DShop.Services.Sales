using System.Threading.Tasks;
using DShop.Common.Consul;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace DShop.Services.Sales.Services.Events.Handlers
{
    public class OrderCreatedHandler : IEventHandler<OrderCreated>
    {
        private readonly IOrdersServiceClient _ordersServiceClient;
        private readonly IConsulHttpClient _consulHttpClient;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderCreatedHandler> _logger;

        public OrderCreatedHandler(IOrdersServiceClient ordersServiceClient, 
            IConsulHttpClient consulHttpClient,
            IOrderRepository orderRepository, ILogger<OrderCreatedHandler> logger)
        {
            _ordersServiceClient = ordersServiceClient;
            _consulHttpClient = consulHttpClient;
            _orderRepository = orderRepository;
            _logger = logger;
        }
        
        public async Task HandleAsync(OrderCreated @event, ICorrelationContext context)
        {
            await Task.CompletedTask;
            _logger.LogInformation($"Adding an order: {@event.Id}");
//            var orderDto = await _ordersServiceClient.GetAsync(@event.Id);
//            var orderDto = await _consulHttpClient.GetAsync<OrderDto>($"orders-service/orders/{@event.Id}");
//            _orderRepository.AddAsync(new Order())
//            throw new System.NotImplementedException();
        }
    }
}