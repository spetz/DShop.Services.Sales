using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;

namespace DShop.Services.Sales.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
    }
}