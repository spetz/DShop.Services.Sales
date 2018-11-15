using System.Threading.Tasks;

namespace DShop.Services.Sales.Services
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}