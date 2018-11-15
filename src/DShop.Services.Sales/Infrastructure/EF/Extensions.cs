using System;
using System.Linq.Expressions;
using DShop.Services.Sales.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace DShop.Services.Sales.Infrastructure.EF
{
    public static class Extensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
            => services.AddEntityFrameworkInMemoryDatabase()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<SalesContext>();

        public static PropertyBuilder<T> HasAggregateIdConversion<T>(this PropertyBuilder<T> builder)
            => builder.HasConversion(new AggregateIdValueConverter());

        private class AggregateIdValueConverter : ValueConverter<AggregateId, Guid>
        {
            public AggregateIdValueConverter() : this(p => p.Value, p => new AggregateId(p))
            {
            }

            private AggregateIdValueConverter(Expression<Func<AggregateId, Guid>> convertToProviderExpression,
                Expression<Func<Guid, AggregateId>> convertFromProviderExpression,
                ConverterMappingHints mappingHints = null) :
                base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
            {
            }
        }
    }
}