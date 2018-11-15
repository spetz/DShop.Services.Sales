using System.Threading.Tasks;

namespace DShop.Services.Sales.Services
{
    public interface IDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}