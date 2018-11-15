using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Infrastructure.EF;

namespace DShop.Services.Sales.Infrastructure.Database.EF.Repositories
{
    public class OrderRepository : IOrderRepository, IEfRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}