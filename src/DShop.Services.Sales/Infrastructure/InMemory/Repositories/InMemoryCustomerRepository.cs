using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;

namespace DShop.Services.Sales.Infrastructure.InMemory.Repositories
{
    //Not thread safe (use concurrent collection), register as a singleton
    public class InMemoryCustomerRepository : ICustomerRepository, IInMemoryRepository
    {
        private readonly ISet<Customer> _customers = new HashSet<Customer>();

        public async Task AddAsync(Customer customer)
        {
            _customers.Add(customer);
            await Task.CompletedTask;
        }
    }
}