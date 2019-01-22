using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Services.Dto;

namespace DShop.Services.Sales.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}