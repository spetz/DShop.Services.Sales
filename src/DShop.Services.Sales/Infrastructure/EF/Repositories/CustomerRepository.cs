using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Infrastructure.EF;

namespace DShop.Services.Sales.Infrastructure.Database.EF.Repositories
{
    public class CustomerRepository : ICustomerRepository, IEfRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}