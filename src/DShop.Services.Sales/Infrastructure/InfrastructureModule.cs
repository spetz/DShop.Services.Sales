using System.Runtime.InteropServices.ComTypes;
using Autofac;
using DShop.Services.Sales.Core.Repositories;
using DShop.Services.Sales.Infrastructure.Database.EF.Repositories;
using DShop.Services.Sales.Infrastructure.EF;
using DShop.Services.Sales.Infrastructure.InMemory.Repositories;

namespace DShop.Services.Sales.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(InfrastructureModule).Assembly;
            
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();

//            builder.RegisterAssemblyTypes(assembly)
//                .AssignableTo<IInMemoryRepository>()
//                .AsImplementedInterfaces()
//                .SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<IEfRepository>()
                .AsImplementedInterfaces();

            builder.RegisterType<EfDataSeeder>()
                .As<IDataSeeder>();
        }
    }
}