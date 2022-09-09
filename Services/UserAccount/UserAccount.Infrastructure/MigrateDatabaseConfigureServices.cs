using Microsoft.Extensions.Hosting;
using UserAccount.Infrastructure.Common.Extensions;
using UserAccount.Infrastructure.Persistence;

namespace UserAccount.Infrastructure
{
    public static class MigrateDatabaseConfigureServices
    {
        public static IHost MigrateDatabaseServices(this IHost host)
        {
            host.MigrateDatabase<UserAccountContext>((context, services) =>
            {
                UserAccountContextSeed
                    .SeedAsync(context)
                    .Wait();
            });

            return host;
        }
    }
}
