using AutoFixture;
using DShop.Common.Dispatchers;
using DShop.Services.Sales.Controllers;
using DShop.Services.Sales.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace DShop.Services.Sales.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void get_should_return_string_content()
        {
            //Arrange
            var fixture = new Fixture();
            var options = fixture.Create<ApplicationOptions>();
            var appOptionsMock = new Mock<IOptions<ApplicationOptions>>();
            var dispatcherMock = new Mock<IDispatcher>();
            appOptionsMock.Setup(x => x.Value).Returns(options);
            
            var controller = new HomeController(appOptionsMock.Object,
                dispatcherMock.Object);
            
            //Act
            var result = controller.Get();
            
            //Assert
            result.Should().BeOfType<ActionResult<string>>()
                .Subject.Value.Should().BeEquivalentTo(options.Name);
        }
    }
}