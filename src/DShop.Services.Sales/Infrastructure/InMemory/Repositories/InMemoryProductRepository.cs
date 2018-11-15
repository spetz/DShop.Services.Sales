using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Infrastructure.InMemory.Repositories
{
    //Not thread safe
    public class InMemoryProductRepository : IProductRepository, IInMemoryRepository
    {
        private readonly ISet<Product> _products = new HashSet<Product>();

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await Task.FromResult(_products);

        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
            => await Task.CompletedTask;

        public async Task DeleteAsync(AggregateId id)
        {
            _products.Remove(_products.SingleOrDefault(p => p.Id.Equals(id)));
            await Task.CompletedTask;
        }
    }
}