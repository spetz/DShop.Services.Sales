using System.Threading.Tasks;
using DShop.Common.Dispatchers;
using DShop.Services.Sales.Infrastructure;
using DShop.Services.Sales.Services.Commands;
using DShop.Services.Sales.Services.Dto;
using DShop.Services.Sales.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Sales.Controllers
{
    [Route("reports/products")]
    public class ProductsReportsController : BaseController
    {
        public ProductsReportsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsReportDto>> Get([FromRoute] GetProductsReport query)
            => Result(await QueryAsync(query));

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductsReport command)
        {
            await SendAsync(command.BindId(c => c.Id));

            return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
        }
    }
}