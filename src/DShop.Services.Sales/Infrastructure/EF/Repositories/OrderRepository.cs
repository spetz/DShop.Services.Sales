using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DShop.Services.Sales.Infrastructure.EF.Repositories
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

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            await _context.OrderItems.ToListAsync();
            var orders = await _context.Orders.ToListAsync();
            
            //var orders = await _context.Orders.Include(o => o.Items).ToListAsync();
            //Include() -> Failed to compare two elements in the array. -> EF so stable.

            return orders;
        }
    }
}