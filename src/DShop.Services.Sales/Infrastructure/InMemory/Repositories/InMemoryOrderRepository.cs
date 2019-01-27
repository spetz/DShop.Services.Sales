using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Infrastructure.InMemory.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository, IInMemoryRepository
    {
        private readonly ISet<Order> _orders = new HashSet<Order>();

        public Task AddAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
            => await Task.FromResult(_orders);
    }
}