using System;
using System.Threading.Tasks;
using DShop.Services.Sales.Services.Dto;

namespace DShop.Services.Sales.Services
{
    public interface IProductsReportingService
    {
        Task<ProductsReportDto> GetAsync(Guid id);
        Task CreateAsync(Guid id, int maxRank);
    }
}