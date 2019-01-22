using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DShop.Services.Sales.Infrastructure.EF.Repositories
{
    public class OrderItemRepository : IOrderItemRepository, IEfRepository
    {
        private readonly SalesContext _context;

        public OrderItemRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
            => await _context.OrderItems.ToListAsync();

        public async Task AddAsync(IEnumerable<OrderItem> items)
        {
            await _context.OrderItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }
    }
}