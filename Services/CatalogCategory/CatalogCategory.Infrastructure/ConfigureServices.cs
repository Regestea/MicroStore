using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.Infrastructure.Persistence;
using CatalogCategory.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogCategory.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICatalogCategoryContext, CatalogCategoryContext>();
            services.AddScoped<ICatalogCategoryRepository, CatalogCategoryRepository>();

            return services;
        }
    }
}
