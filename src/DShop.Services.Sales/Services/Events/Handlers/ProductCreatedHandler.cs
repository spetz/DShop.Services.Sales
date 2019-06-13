using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;

namespace DShop.Services.Sales.Services.Events.Handlers
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        public Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}