using System;
using DShop.Common.Messages;
using Newtonsoft.Json;

namespace DShop.Services.Sales.Services.Events
{
    [MessageNamespace("orders")]
    public class OrderCreated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public OrderCreated(Guid id)
        {
            Id = id;
        }
    }
}