using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Infrastructure.InMemory.Repositories
{
    public class InMemoryProductsReportRepository : IProductsReportRepository, IInMemoryRepository
    {
        private readonly ISet<ProductsReport> _reports = new HashSet<ProductsReport>();

        public async Task<ProductsReport> GetAsync(AggregateId id)
            => await Task.FromResult(_reports.SingleOrDefault(r => r.Id.Equals(id)));

        public async Task AddAsync(ProductsReport report)
        {
            _reports.Add(report);
            await Task.CompletedTask;
        }
    }
}