using System;
using DShop.Common.Messages;
using Newtonsoft.Json;

namespace DShop.Services.Sales.Services.Events
{
    [MessageNamespace("products")]
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}