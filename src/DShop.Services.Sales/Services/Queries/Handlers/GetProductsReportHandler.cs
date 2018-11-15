using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Services.Dto;

namespace DShop.Services.Sales.Services.Queries.Handlers
{
    public class GetProductsReportHandler : IQueryHandler<GetProductsReport, ProductsReportDto>
    {
        private readonly IProductsReportRepository _productsReportRepository;

        public GetProductsReportHandler(IProductsReportRepository productsReportRepository)
        {
            _productsReportRepository = productsReportRepository;
        }
        
        public async Task<ProductsReportDto> HandleAsync(GetProductsReport query)
            => await _productsReportRepository.GetAsync(query.Id)
                .ContinueWith(t => Map(t.Result));
        
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