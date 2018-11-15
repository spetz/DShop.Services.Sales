using System.Threading.Tasks;

namespace DShop.Services.Sales.Infrastructure
{
    public interface IDataSeeder
    {
        Task SeedAsync();
    }
}