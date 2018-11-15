using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Infrastructure.InMemory.Repositories
{
    public class InMemoryOrderItemRepository : IOrderItemRepository, IInMemoryRepository
    {
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
            => await Task.FromResult(_items);

        public async Task AddAsync(IEnumerable<OrderItem> items)
        {
            foreach (var item in items)
            {
                _items.Add(item);
            }
            await Task.CompletedTask;
        }
    }
}