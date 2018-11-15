using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DShop.Services.Sales.Services.Commands;
using DShop.Services.Sales.Services.Dto;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace DShop.Services.Sales.Tests.EndToEnd.Controllers
{
    public class ProductsReportsControllerTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;
        
        public ProductsReportsControllerTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task post_should_create_report()
        {
            var command = new CreateProductsReport(Guid.Empty, 5);

            var response = await _client.PostAsJsonAsync("reports/products", command);

            response.IsSuccessStatusCode.Should().BeTrue();
            response.Headers.Location.Should().NotBeNull();

            var productResponse = await _client.GetAsync(response.Headers.Location.AbsolutePath);
            var content = await productResponse.Content.ReadAsStringAsync();
            
            var product = JsonConvert.DeserializeObject<ProductsReportDto>(content);
            product.Products.Should().NotBeEmpty();
        }
    }
}