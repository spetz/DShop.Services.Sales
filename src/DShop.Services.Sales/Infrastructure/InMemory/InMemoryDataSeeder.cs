using System.Threading.Tasks;

namespace DShop.Services.Sales.Infrastructure.InMemory
{
    public class InMemoryDataSeeder : IDataSeeder
    {
        private readonly IDataInitializer _dataInitializer;

        public InMemoryDataSeeder(IDataInitializer dataInitializer)
        {
            _dataInitializer = dataInitializer;
        }

        public async Task SeedAsync() => await _dataInitializer.InitializeAsync();
    }
}