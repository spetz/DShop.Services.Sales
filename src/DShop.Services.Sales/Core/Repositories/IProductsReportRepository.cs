using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Repositories
{
    public interface IProductsReportRepository
    {
        
        Task<ProductsReport> GetAsync(AggregateId id);
        Task AddAsync(ProductsReport report);
    }
}