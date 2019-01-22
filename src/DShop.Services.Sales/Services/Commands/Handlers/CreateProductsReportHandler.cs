using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Core.Factories;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Services.Commands.Handlers
{
    public class CreateProductsReportHandler : ICommandHandler<CreateProductsReport>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductsReportRepository _productsReportRepository;
        private readonly IProductsReportFactory _productsReportFactory;

        public CreateProductsReportHandler(IProductRepository productRepository,
            IOrderItemRepository orderItemRepository,
            IProductsReportRepository productsReportRepository,
            IProductsReportFactory productsReportFactory)
        {
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
            _productsReportRepository = productsReportRepository;
            _productsReportFactory = productsReportFactory;
        }
        
        public async Task HandleAsync(CreateProductsReport command, ICorrelationContext context)
        {
            var report = _productsReportFactory.Create(command.Id,
                await _productRepository.GetAllAsync(),
                await _orderItemRepository.GetAllAsync(), command.MaxRank);
            await _productsReportRepository.AddAsync(report);
        }
    }
}