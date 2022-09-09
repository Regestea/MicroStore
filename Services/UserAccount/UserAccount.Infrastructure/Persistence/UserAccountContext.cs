using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserAccount.Domain.Entities;

namespace UserAccount.Infrastructure.Persistence
{
    public class UserAccountContext : DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
