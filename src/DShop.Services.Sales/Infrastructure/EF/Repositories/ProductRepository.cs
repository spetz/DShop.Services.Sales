using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DShop.Services.Sales.Infrastructure.EF.Repositories
{
    public class ProductRepository : IProductRepository, IEfRepository
    {
        private readonly SalesContext _context;

        public ProductRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
            => await _context.SaveChangesAsync();

        public async Task DeleteAsync(AggregateId id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}