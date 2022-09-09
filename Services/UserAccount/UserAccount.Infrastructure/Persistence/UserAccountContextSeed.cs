using UserAccount.Domain.Entities;

namespace UserAccount.Infrastructure.Persistence
{
    public class UserAccountContextSeed
    {
        public static async Task SeedAsync(UserAccountContext accountContext)
        {
            if (!accountContext.Users.Any())
            {
                accountContext.Users.Add(new User() { Name = "User1", Email = "User1@gmail.com" });

                await accountContext.SaveChangesAsync();
            }

            if (!accountContext.Addresses.Any())
            {
                var firstUser = accountContext.Users.First();

                accountContext.Addresses.Add(new Address() { UserId = firstUser.Id, Country = "united states", LoctionAddress = "new york song city" });

                await accountContext.SaveChangesAsync();
            }
        }
    }
}