using System;
using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Factories;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Services.Dto;

namespace DShop.Services.Sales.Services
{
    public class ProductsReportingService : IProductsReportingService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductsReportRepository _productsReportRepository;
        private readonly IProductsReportFactory _productsReportFactory;

        public ProductsReportingService(IProductRepository productRepository,
            IOrderRepository orderRepository,
            IProductsReportRepository productsReportRepository,
            IProductsReportFactory productsReportFactory)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _productsReportRepository = productsReportRepository;
            _productsReportFactory = productsReportFactory;
        }
        
        public async Task<ProductsReportDto> GetAsync(Guid id)
            => await _productsReportRepository.GetAsync(id)
                .ContinueWith(t => Map(t.Result));

        public async Task CreateAsync(Guid id, int maxRank)
        {
            var products = _productRepository.GetAllAsync();
            var orders = _orderRepository.GetAllAsync();
            await Task.WhenAll(products, orders);
            var report = _productsReportFactory.Create(id,
                products.Result.ToList(), orders.Result.ToList(), maxRank);
            await _productsReportRepository.AddAsync(report);
        }

        private static ProductsReportDto Map(ProductsReport report)
            => report == null
                ? null
                : new ProductsReportDto
                {
                    Id = report.Id,
                    Products = report.Products.Select(p => new ProductRankDto
                    {
                        Rank = p.Rank,
                        Product = new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Vendor = p.Vendor,
                            Price = p.Price,
                        },
                        TotalSales = p.TotalSales,
                        TotalEarnings = p.TotalEarnings
                    }),
                    CreatedAt = report.CreatedAt
                };
    }
}