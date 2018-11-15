using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DShop.Services.Sales.Infrastructure.EF
{
    public class EfDataSeeder : IDataSeeder
    {
        private readonly SalesContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataInitializer _dataInitializer;
        private readonly IOptions<SqlOptions> _options;

        public EfDataSeeder(SalesContext context, IUnitOfWork unitOfWork,
            IDataInitializer dataInitializer, IOptions<SqlOptions> options)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _dataInitializer = dataInitializer;
            _options = options;
        }

        public async Task SeedAsync()
        {
            if (_options.Value.InMemory)
            {
                await _dataInitializer.InitializeAsync();

                return;
            }

            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
            if (await _context.Customers.AnyAsync())
            {
                return;
            }

            await _unitOfWork.ExecuteAsync(() => _dataInitializer.InitializeAsync());
        }
    }
}