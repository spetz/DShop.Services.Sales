using System;
using System.Linq;
using AutoFixture;
using DShop.Services.Sales.Core.Domain;
using DShop.Services.Sales.Core.Exceptions;
using DShop.Services.Sales.Core.Factories;
using DShop.Services.Sales.Core.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace DShop.Services.Sales.Tests.Factories
{
    public class ProductsReportFactoryTests
    {
        private readonly Mock<IProductSalesCalculator> _productSalesCalculatorMock;
        
        public ProductsReportFactoryTests()
        {
            _productSalesCalculatorMock = new Mock<IProductSalesCalculator>();
        }

        [Fact]
        public void should_fail_for_empty_products()
        {
            var factory = new ProductsReportFactory(_productSalesCalculatorMock.Object);

            Action createReport = () => factory.Create(Guid.NewGuid(), null, null, 3);

            createReport.Should().Throw<EmptyProductsException>();
        }
        
        [Fact]
        public void create_should_return_report()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>().ToList();
            var orders = fixture.CreateMany<Order>().ToList();
            var sales = products.Select(p => CreateSales(p, fixture.Create<int>()));
            var reportFactory = new ProductsReportFactory(_productSalesCalculatorMock.Object);
            _productSalesCalculatorMock.Setup(x => x.Calculate(products, orders))
                .Returns(sales);

            var report = reportFactory.Create(Guid.NewGuid(), products, orders, 3);

            report.Should().NotBeNull();
        }
        
        private ProductSales CreateSales(Product product, int totalSales)
            => new ProductSales(product.Id, totalSales);
    }
}