using System.Linq;
using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Core.Factories;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace DShop.Services.Sales.Services.Commands.Handlers
{
    public class CreateProductsReportHandler : ICommandHandler<CreateProductsReport>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductsReportRepository _productsReportRepository;
        private readonly IProductsReportFactory _productsReportFactory;
        private readonly ILogger<CreateProductsReportHandler> _logger;

        public CreateProductsReportHandler(IProductRepository productRepository,
            IOrderRepository orderRepository,
            IProductsReportRepository productsReportRepository,
            IProductsReportFactory productsReportFactory,
            ILogger<CreateProductsReportHandler> logger)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _productsReportRepository = productsReportRepository;
            _productsReportFactory = productsReportFactory;
            _logger = logger;
        }
        
        public async Task HandleAsync(CreateProductsReport command, ICorrelationContext context)
        {
            _logger.LogInformation($"Creating a report: {command.Id}");
            var products = _productRepository.GetAllAsync();
            var orders = _orderRepository.GetAllAsync();
            await Task.WhenAll(products, orders);
            var report = _productsReportFactory.Create(command.Id,
                products.Result.ToList(), orders.Result.ToList(), command.MaxRank);
            await _productsReportRepository.AddAsync(report);
        }
    }
}