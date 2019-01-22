using DShop.Common.Dispatchers;
using DShop.Services.Sales.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DShop.Services.Sales.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        private readonly IOptions<ApplicationOptions> _applicationOptions;

        public HomeController(IOptions<ApplicationOptions> applicationOptions,
            IDispatcher dispatcher) : base(dispatcher)
        {
            _applicationOptions = applicationOptions;
        }

        [HttpGet]
        public ActionResult<string> Get() => _applicationOptions.Value.Name;
    }
}