using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DShop.Services.Sales.Tests.Integration.Controllers
{
    public class HomeControllerTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;
        
        public HomeControllerTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }
        
        [Fact]
        public async Task get_should_return_string_content()
        {
            var response = await _client.GetAsync("/");
            response.IsSuccessStatusCode.Should().BeTrue();

            var content = await response.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo("DShop Sales Service Test");
        }
    }
}