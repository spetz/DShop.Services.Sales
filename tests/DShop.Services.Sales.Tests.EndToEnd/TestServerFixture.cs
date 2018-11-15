using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;

namespace DShop.Services.Sales.Tests.EndToEnd
{
    public class TestServerFixture : IDisposable
    {
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath,
                "../../../../../src/DShop.Services.Sales"));

            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("test")
                .UseContentRoot(applicationPath));

            Client = server.CreateClient();
        }
        
        public void Dispose()
        {
        }
    }
}