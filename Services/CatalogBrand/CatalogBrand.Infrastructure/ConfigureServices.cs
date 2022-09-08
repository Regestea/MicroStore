using CatalogBrand.Application.Common.Interfaces;
using CatalogBrand.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogBrand.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICatalogBrandContext, CatalogBrandContext>();

            return services;
        }
    }
}
