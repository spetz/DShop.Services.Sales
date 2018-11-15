using System;
using System.Collections.Generic;

namespace DShop.Services.Sales.Services.Dto
{
    public class ProductsReportDto
    {
        public Guid Id { get; set; }
        public IEnumerable<ProductRankDto> Products { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}