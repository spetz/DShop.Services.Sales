using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DShop.Common.Dispatchers;
using DShop.Common.Mvc;
using DShop.Common.RabbitMq;
using DShop.Services.Sales.Infrastructure;
using DShop.Services.Sales.Infrastructure.EF;
using DShop.Services.Sales.Services.Events;
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
            services.AddCustomMvc();
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
            builder.AddRabbitMq();

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

            app.UseErrorHandler();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeEvent<ProductCreated>();

            lifetime.ApplicationStopped.Register(() => Container.Dispose());
            dataSeeder.SeedAsync().Wait();
        }
    }
}
