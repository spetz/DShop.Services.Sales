using System;
using Newtonsoft.Json;

namespace DShop.Services.Sales.Services.Commands
{
    public class CreateProductsReport : ICommand
    {
        public Guid Id { get; }
        public int MaxRank { get; }
        
        [JsonConstructor]
        public CreateProductsReport(Guid id, int maxRank)
        {
            Id = id;
            MaxRank = maxRank;
        }
    }
}