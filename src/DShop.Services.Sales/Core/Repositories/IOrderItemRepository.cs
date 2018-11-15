using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task AddAsync(IEnumerable<OrderItem> items);
    }
}