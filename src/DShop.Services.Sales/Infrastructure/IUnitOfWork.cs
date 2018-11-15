using System;
using System.Threading.Tasks;

namespace DShop.Services.Sales.Infrastructure
{
    public interface IUnitOfWork
    {
        Task ExecuteAsync(Func<Task> query);
    }
}