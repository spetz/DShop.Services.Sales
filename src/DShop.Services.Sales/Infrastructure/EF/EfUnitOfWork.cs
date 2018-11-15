using System;
using System.Threading.Tasks;

namespace DShop.Services.Sales.Infrastructure.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly SalesContext _context;

        public EfUnitOfWork(SalesContext context)
        {
            _context = context;
        }
        
        public async Task ExecuteAsync(Func<Task> query)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                await query();
                transaction.Commit();
            }
        }
    }
}