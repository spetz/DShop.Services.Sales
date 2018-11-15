using System.Threading.Tasks;

namespace DShop.Services.Sales.Services
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}