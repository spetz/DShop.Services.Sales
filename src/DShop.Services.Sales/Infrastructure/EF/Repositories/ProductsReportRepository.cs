using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace DShop.Services.Sales.Infrastructure.Database.EF.Repositories
{
    public class ProductsReportRepository : IProductsReportRepository, IEfRepository
    {
        private readonly SalesContext _context;

        public ProductsReportRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<ProductsReport> GetAsync(AggregateId id)
            => await _context.ProductsReports.SingleOrDefaultAsync(r => r.Id.Equals(id));

        public async Task AddAsync(ProductsReport report)
        {
            await _context.ProductsReports.AddAsync(report);
            await _context.SaveChangesAsync();
        }
    }
}