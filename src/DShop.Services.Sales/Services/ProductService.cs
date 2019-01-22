using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Services.Dto;

namespace DShop.Services.Sales.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
            => await _productRepository.GetAllAsync()
                .ContinueWith(t => t.Result.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Vendor = p.Vendor,
                    Price = p.Price
                }));
    }
}