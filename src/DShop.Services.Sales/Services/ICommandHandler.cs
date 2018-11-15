using System.Threading.Tasks;

namespace DShop.Services.Sales.Services
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}