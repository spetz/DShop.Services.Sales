using System.Threading.Tasks;

namespace DShop.Services.Sales.Services
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}