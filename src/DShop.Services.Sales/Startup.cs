using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DShop.Common.Dispatchers;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Infrastructure;
using DShop.Services.Sales.Infrastructure.EF;
using DShop.Services.Sales.Infrastructure.InMemory;
using DShop.Services.Sales.Infrastructure.InMemory.Repositories;
using DShop.Services.Sales.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DShop.Services.Sales
{
    public class Startup
    {
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(o => o.Formatting = Formatting.Indented);
            services.Configure<ApplicationOptions>(Configuration.GetSection("application"));
            services.Configure<SqlOptions>(Configuration.GetSection("sql"));
            services.AddEntityFramework();

            return BuildContainer(services);
        }
        
        private IServiceProvider BuildContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.RegisterModule<InfrastructureModule>();
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime lifetime, IDataSeeder dataSeeder)
        {
            if (env.IsDevelopment() || env.IsEnvironment("local"))
            {
                app.UseDeveloperExceptionPage();
            }

//            else
//            {
//                Production environment with TLS enabled
//                app.UseHsts();
//                app.UseHttpsRedirection();
//            }

            app.UseMvc();
            lifetime.ApplicationStopped.Register(() => Container.Dispose());
            dataSeeder.SeedAsync().Wait();
        }
    }
}
