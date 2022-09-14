using AWS.Application.Common.Interfaces;
using AWS.Infrastructure.Persistence.AWS;
using AWS.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAWSFileRepository, AWSFileRepository>();

            services.AddSingleton<IAmazonS3ClientContext, AmazonS3ClientContext>();

            return services;
        }
    }
}
